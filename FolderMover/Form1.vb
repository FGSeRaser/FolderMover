Imports System.IO
Imports System.ComponentModel
Imports System.Threading
Imports Newtonsoft.Json

Public Class Form1
    Private actionAfterSuccess As String = "NONE"   ' "NONE", "SHUTDOWN", "STANDBY"
    Private profiles As New List(Of TransferProfile)
    Private profilesFile As String = Path.Combine(Application.StartupPath, "profiles.json")
    Private quellPfad As String = ""
    Private zielPfad As String = ""
    Private modus As String = ""
    Private istPausiert As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProfiles()
        Me.Text = "FolderMover"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = True
        Me.AllowDrop = True

        ' Startgröße OHNE Log
        Me.Size = New Size(650, 359)

        ' Statuslabel mittig, feste Größe
        LblStatus.AutoSize = False
        LblStatus.TextAlign = ContentAlignment.MiddleCenter
        LblStatus.BorderStyle = BorderStyle.FixedSingle
        LblStatus.Text = "Drag & Drop Ordner hier hinein oder Buttons nutzen"

        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Continuous

        BtnVerschieben.Enabled = False
        BtnKopieren.Enabled = False
        BtnPause.Enabled = False
        BtnAbbrechen.Enabled = False

        ' Log-Panel initial aus
        PanelLog.Visible = False
        BtnLog.Text = "Log anzeigen"
    End Sub
    Private isLoadingProfiles As Boolean = False
    Private Sub RbKeine_CheckedChanged(sender As Object, e As EventArgs) Handles RbKeine.CheckedChanged
        If RbKeine.Checked Then
            actionAfterSuccess = "NONE"
        End If
    End Sub

    Private Sub RbShutdown_CheckedChanged(sender As Object, e As EventArgs) Handles RbShutdown.CheckedChanged
        If RbShutdown.Checked Then
            Dim result = MessageBox.Show("Nach erfolgreichem Vorgang PC automatisch herunterfahren?",
                                     "Aktion nach Erfolg",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                actionAfterSuccess = "SHUTDOWN"
            Else
                ' Auswahl zurücksetzen
                RbShutdown.Checked = False
                RbKeine.Checked = True
                actionAfterSuccess = "NONE"
            End If
        End If
    End Sub

    Private Sub RbStandby_CheckedChanged(sender As Object, e As EventArgs) Handles RbStandby.CheckedChanged
        If RbStandby.Checked Then
            Dim result = MessageBox.Show("Nach erfolgreichem Vorgang PC automatisch in Standby versetzen?",
                                     "Aktion nach Erfolg",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                actionAfterSuccess = "STANDBY"
            Else
                RbStandby.Checked = False
                RbKeine.Checked = True
                actionAfterSuccess = "NONE"
            End If
        End If
    End Sub

    Private Sub LoadProfiles()
        isLoadingProfiles = True

        profiles.Clear()

        If File.Exists(profilesFile) Then
            Try
                Dim json = File.ReadAllText(profilesFile)
                Dim loaded = JsonConvert.DeserializeObject(Of List(Of TransferProfile))(json)
                If loaded IsNot Nothing Then
                    profiles = loaded
                End If
            Catch ex As Exception
                AddLog("Fehler beim Laden der Profile: " & ex.Message)
            End Try
        End If

        CmbProfile.DataSource = Nothing

        If profiles IsNot Nothing AndAlso profiles.Count > 0 Then
            CmbProfile.DataSource = profiles
            CmbProfile.DisplayMember = "Name"
            CmbProfile.ValueMember = "Name"
        End If

        ' WICHTIG: keine Auswahl nach dem Laden
        CmbProfile.SelectedIndex = -1
        TxtProfileName.Clear()
        ' Optional auch Pfade leeren, damit nichts „aktiv“ ist:
        'TxtQuellPfad.Clear()
        'TxtZielPfad.Clear()
        'quellPfad = ""
        'zielPfad = ""
        'modus = ""

        isLoadingProfiles = False
    End Sub

    Private Sub SaveProfiles()
        Try
            Dim json = JsonConvert.SerializeObject(profiles, Formatting.Indented)
            File.WriteAllText(profilesFile, json)
            AddLog("Profile gespeichert.")
        Catch ex As Exception
            AddLog("Fehler beim Speichern der Profile: " & ex.Message)
        End Try
    End Sub

    ' ------------------- Log-Helfer -------------------
    Private Sub AddLog(msg As String)
        Dim zeile = $"{DateTime.Now:HH:mm:ss}  {msg}"
        ListLog.Items.Add(zeile)
        ListLog.TopIndex = ListLog.Items.Count - 1
    End Sub

    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        PanelLog.Visible = Not PanelLog.Visible

        If PanelLog.Visible Then
            BtnLog.Text = "Log ausblenden"
            Me.Size = New Size(650, 509)   ' mit Log
        Else
            BtnLog.Text = "Log anzeigen"
            Me.Size = New Size(650, 359)   ' ohne Log
        End If
    End Sub

    ' ------------------- Pfadwahl -------------------
    Private Sub BtnQuellOrdner_Click(sender As Object, e As EventArgs) Handles BtnQuellOrdner.Click
        Using fbd As New FolderBrowserDialog()
            fbd.Description = "Quellordner auswählen"
            If fbd.ShowDialog() = DialogResult.OK Then
                TxtQuellPfad.Text = fbd.SelectedPath
                quellPfad = fbd.SelectedPath
                PruefePfade()
            End If
        End Using
    End Sub

    Private Sub BtnZielOrdner_Click(sender As Object, e As EventArgs) Handles BtnZielOrdner.Click
        Using fbd As New FolderBrowserDialog()
            fbd.Description = "Zielordner auswählen"
            If fbd.ShowDialog() = DialogResult.OK Then
                TxtZielPfad.Text = fbd.SelectedPath
                zielPfad = fbd.SelectedPath
                PruefePfade()
            End If
        End Using
    End Sub

    Private Sub PruefePfade()
        Dim quellOK = Not String.IsNullOrEmpty(quellPfad) AndAlso Directory.Exists(quellPfad)
        Dim zielOK = Not String.IsNullOrEmpty(zielPfad)

        BtnVerschieben.Enabled = quellOK AndAlso zielOK
        BtnKopieren.Enabled = BtnVerschieben.Enabled

        LblQuellStatus.Text = If(quellOK, "✓ OK", "✖ Wähle Ordner")
        LblQuellStatus.ForeColor = If(quellOK, Color.DarkGreen, Color.DarkRed)
        LblZielStatus.Text = If(zielOK, "✓ OK", "✖ Wähle Ordner")
        LblZielStatus.ForeColor = If(zielOK, Color.DarkGreen, Color.DarkRed)
    End Sub

    Private Sub TxtQuellPfad_TextChanged(sender As Object, e As EventArgs) Handles TxtQuellPfad.TextChanged
        PruefePfade()
    End Sub

    Private Sub TxtZielPfad_TextChanged(sender As Object, e As EventArgs) Handles TxtZielPfad.TextChanged
        PruefePfade()
    End Sub

    ' ------------------- Start Aktionen -------------------
    Private Sub BtnVerschieben_Click(sender As Object, e As EventArgs) Handles BtnVerschieben.Click
        StarteOperation("VERSCHIEBEN")
    End Sub

    Private Sub BtnKopieren_Click(sender As Object, e As EventArgs) Handles BtnKopieren.Click
        StarteOperation("KOPIEREN")
    End Sub

    Private Sub StarteOperation(modusNeu As String)
        modus = modusNeu
        Dim zielOrdnerName = Path.GetFileName(quellPfad)
        Dim vollerZielPfad = Path.Combine(zielPfad, zielOrdnerName)

        If Directory.Exists(vollerZielPfad) Then
            If MessageBox.Show(
                "Zielordner '" & zielOrdnerName & "' existiert!" & Environment.NewLine &
                "Überschreiben (" & modus & ")?",
                "Bestätigung", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then

                AddLog("Aktion abgebrochen (Ziel existiert).")
                Return
            End If
        End If

        ProgressBar1.Value = 0
        LblStatus.Text = "Starte " & modus & "..."
        BtnVerschieben.Enabled = False
        BtnKopieren.Enabled = False
        BtnPause.Enabled = True
        BtnAbbrechen.Enabled = True
        istPausiert = False
        BtnPause.Text = "Pause"

        AddLog("Starte " & modus & " von " & quellPfad & " nach " & zielPfad)

        BackgroundWorker1.RunWorkerAsync()
    End Sub

    ' ------------------- Pause / Abbruch -------------------
    Private Sub BtnPause_Click(sender As Object, e As EventArgs) Handles BtnPause.Click
        istPausiert = Not istPausiert
        If istPausiert Then
            BtnPause.Text = "Fortsetzen"
            LblStatus.Text = "Pausiert – Fortsetzen klicken"
            AddLog("Pausiert")
        Else
            BtnPause.Text = "Pause"
            AddLog("Fortgesetzt")
        End If
    End Sub

    Private Sub BtnAbbrechen_Click(sender As Object, e As EventArgs) Handles BtnAbbrechen.Click
        BackgroundWorker1.CancelAsync()
        LblStatus.Text = "Abbruch wird verarbeitet..."
        AddLog("Abbruch angefordert")
    End Sub

    ' ------------------- BackgroundWorker -------------------
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim worker = DirectCast(sender, BackgroundWorker)

        Try
            Dim dateien = Directory.GetFiles(quellPfad, "*.*", SearchOption.AllDirectories)
            Dim gesamt = dateien.Length
            worker.ReportProgress(0, $"Analysiere {gesamt} Dateien für {modus}...")

            Dim verarbeitet As Integer = 0

            For Each datei In dateien
                ' Pause
                While istPausiert AndAlso Not worker.CancellationPending
                    Threading.Thread.Sleep(100)
                End While

                ' Abbruch
                If worker.CancellationPending Then
                    e.Cancel = True
                    Exit For
                End If

                Dim relPfad = datei.Substring(quellPfad.Length + 1)
                Dim zielDatei = Path.Combine(zielPfad, Path.GetFileName(quellPfad), relPfad)
                Dim zielOrdner = Path.GetDirectoryName(zielDatei)

                If Not Directory.Exists(zielOrdner) Then
                    Directory.CreateDirectory(zielOrdner)
                End If

                If modus = "KOPIEREN" Then
                    File.Copy(datei, zielDatei, True)
                Else
                    File.Move(datei, zielDatei)
                End If

                verarbeitet += 1
                Dim prozent = CInt(verarbeitet * 100 / Math.Max(1, gesamt))
                worker.ReportProgress(prozent, $"{modus}: {verarbeitet}/{gesamt}: {Path.GetFileName(datei)}")
            Next

        Catch ex As Exception
            e.Result = ex
        End Try
    End Sub



    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        Dim txt = CStr(e.UserState)
        LblStatus.Text = txt
        LblStatus.TextAlign = ContentAlignment.MiddleCenter
        AddLog(txt)
    End Sub


    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ' UI zurücksetzen
        ProgressBar1.Visible = False
        BtnVerschieben.Enabled = True
        BtnKopieren.Enabled = True
        BtnPause.Enabled = False
        BtnAbbrechen.Enabled = False
        istPausiert = False
        BtnPause.Text = "Pause"

        ' Abbruch?
        If e.Cancelled Then
            LblStatus.Text = "Abgebrochen."
            LblStatus.TextAlign = ContentAlignment.MiddleCenter
            AddLog("Aktion abgebrochen.")
            Return
        End If

        ' Fehler direkt aus dem BackgroundWorker
        If e.Error IsNot Nothing Then
            LblStatus.Text = "Fehler: " & e.Error.Message
            LblStatus.TextAlign = ContentAlignment.MiddleCenter
            AddLog("Fehler: " & e.Error.Message)
            Return
        End If

        ' Falls im DoWork explizit eine Exception in Result übergeben wurde
        Dim ex = TryCast(e.Result, Exception)
        If ex IsNot Nothing Then
            LblStatus.Text = "Fehler: " & ex.Message
            LblStatus.TextAlign = ContentAlignment.MiddleCenter
            AddLog("Fehler: " & ex.Message)
            Return
        End If

        ' Erfolg
        Dim zielOrdnerName = Path.GetFileName(quellPfad)
        Dim zielVoll = Path.Combine(zielPfad, zielOrdnerName)

        LblStatus.Text = modus & " erfolgreich abgeschlossen."
        LblStatus.TextAlign = ContentAlignment.MiddleCenter
        AddLog($"{modus} erfolgreich abgeschlossen: {zielVoll}")

        ' Aktion nach Erfolg - KEINE weitere Nachfrage mehr
        Try
            Select Case actionAfterSuccess   ' "NONE", "SHUTDOWN", "STANDBY"
                Case "SHUTDOWN"
                    Process.Start("shutdown", "/s /t 0")
                Case "STANDBY"
                    Application.SetSuspendState(PowerState.Suspend, True, False)
                Case Else
                    ' Keine Aktion
            End Select
        Catch ex2 As Exception
            AddLog("Fehler bei Aktion nach Erfolg: " & ex2.Message)
        End Try
    End Sub




    ' ------------------- Drag & Drop (optional) -------------------
    Private Sub Form1_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
        Dim paths() = CType(e.Data.GetData(DataFormats.FileDrop), String())
        If paths.Length > 0 AndAlso Directory.Exists(paths(0)) Then
            TxtQuellPfad.Text = paths(0)
            quellPfad = paths(0)
            PruefePfade()
            AddLog("Quellordner per Drag & Drop: " & paths(0))
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(TxtProfileName.Text) Then
            MessageBox.Show("Bitte einen Profilnamen eingeben.", "Profil", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If String.IsNullOrWhiteSpace(quellPfad) OrElse String.IsNullOrWhiteSpace(zielPfad) Then
            MessageBox.Show("Quell- und Zielordner müssen gesetzt sein.", "Profil", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim name = TxtProfileName.Text.Trim()
        Dim existing = profiles.FirstOrDefault(Function(p) p.Name.Equals(name, StringComparison.OrdinalIgnoreCase))

        ' aktuellen Modus ableiten – falls nichts gesetzt, default auf KOPIEREN
        Dim currentMode As String = If(modus = "KOPIEREN" OrElse modus = "VERSCHIEBEN", modus, "KOPIEREN")

        If existing Is Nothing Then
            Dim p As New TransferProfile With {
            .Name = name,
            .SourcePath = quellPfad,
            .TargetPath = zielPfad,
            .DefaultMode = currentMode
        }
            profiles.Add(p)
            AddLog("Neues Profil angelegt: " & name)
        Else
            existing.SourcePath = quellPfad
            existing.TargetPath = zielPfad
            existing.DefaultMode = currentMode
            AddLog("Profil aktualisiert: " & name)
        End If

        SaveProfiles()
        LoadProfiles()
        CmbProfile.SelectedItem = profiles.FirstOrDefault(Function(p) p.Name = name)
    End Sub

    Private Sub BtnProfileDelete_Click(sender As Object, e As EventArgs) Handles BtnProfileDelete.Click
        Dim sel = TryCast(CmbProfile.SelectedItem, TransferProfile)
        If sel Is Nothing Then
            MessageBox.Show("Kein Profil ausgewählt.", "Profil löschen", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If MessageBox.Show("Profil '" & sel.Name & "' wirklich löschen?",
                       "Profil löschen",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) = DialogResult.Yes Then

            profiles.Remove(sel)
            SaveProfiles()
            LoadProfiles()
            AddLog("Profil gelöscht: " & sel.Name)

            ' HIER: Felder und Auswahl zurücksetzen
            CmbProfile.SelectedIndex = -1
            TxtProfileName.Clear()
            TxtQuellPfad.Clear()
            TxtZielPfad.Clear()
            quellPfad = ""
            zielPfad = ""
            modus = ""
            PruefePfade()
        End If
    End Sub
    Private Sub CmbProfile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbProfile.SelectedIndexChanged
        If isLoadingProfiles Then Return
        If CmbProfile.SelectedIndex < 0 Then Return

        Dim sel = TryCast(CmbProfile.SelectedItem, TransferProfile)
        If sel Is Nothing Then Return

        TxtProfileName.Text = sel.Name
        TxtQuellPfad.Text = sel.SourcePath
        TxtZielPfad.Text = sel.TargetPath
        quellPfad = sel.SourcePath
        zielPfad = sel.TargetPath
        modus = sel.DefaultMode
        PruefePfade()
        AddLog("Profil geladen: " & sel.Name & " (" & modus & ")")
    End Sub


End Class
Public Class TransferProfile
    Public Property Name As String
    Public Property SourcePath As String
    Public Property TargetPath As String
    Public Property DefaultMode As String   ' "KOPIEREN" oder "VERSCHIEBEN"
End Class
