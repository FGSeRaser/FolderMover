<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.LblQuellPfad = New System.Windows.Forms.Label()
        Me.TxtQuellPfad = New System.Windows.Forms.TextBox()
        Me.BtnQuellOrdner = New System.Windows.Forms.Button()
        Me.LblZielPfad = New System.Windows.Forms.Label()
        Me.TxtZielPfad = New System.Windows.Forms.TextBox()
        Me.BtnZielOrdner = New System.Windows.Forms.Button()
        Me.LblQuellStatus = New System.Windows.Forms.Label()
        Me.LblZielStatus = New System.Windows.Forms.Label()
        Me.BtnVerschieben = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BtnKopieren = New System.Windows.Forms.Button()
        Me.BtnPause = New System.Windows.Forms.Button()
        Me.BtnAbbrechen = New System.Windows.Forms.Button()
        Me.PanelLog = New System.Windows.Forms.Panel()
        Me.ListLog = New System.Windows.Forms.ListBox()
        Me.BtnLog = New System.Windows.Forms.Button()
        Me.TxtProfileName = New System.Windows.Forms.TextBox()
        Me.CmbProfile = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BtnProfileDelete = New System.Windows.Forms.Button()
        Me.RbKeine = New System.Windows.Forms.RadioButton()
        Me.RbShutdown = New System.Windows.Forms.RadioButton()
        Me.RbStandby = New System.Windows.Forms.RadioButton()
        Me.PanelLog.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblQuellPfad
        '
        Me.LblQuellPfad.AutoSize = True
        Me.LblQuellPfad.BackColor = System.Drawing.Color.Gray
        Me.LblQuellPfad.Font = New System.Drawing.Font("Bahnschrift", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblQuellPfad.Location = New System.Drawing.Point(243, 9)
        Me.LblQuellPfad.Name = "LblQuellPfad"
        Me.LblQuellPfad.Size = New System.Drawing.Size(78, 16)
        Me.LblQuellPfad.TabIndex = 0
        Me.LblQuellPfad.Text = "Quellordner"
        '
        'TxtQuellPfad
        '
        Me.TxtQuellPfad.AllowDrop = True
        Me.TxtQuellPfad.Location = New System.Drawing.Point(10, 28)
        Me.TxtQuellPfad.Name = "TxtQuellPfad"
        Me.TxtQuellPfad.ReadOnly = True
        Me.TxtQuellPfad.Size = New System.Drawing.Size(511, 23)
        Me.TxtQuellPfad.TabIndex = 1
        '
        'BtnQuellOrdner
        '
        Me.BtnQuellOrdner.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnQuellOrdner.Location = New System.Drawing.Point(527, 28)
        Me.BtnQuellOrdner.Name = "BtnQuellOrdner"
        Me.BtnQuellOrdner.Size = New System.Drawing.Size(100, 23)
        Me.BtnQuellOrdner.TabIndex = 2
        Me.BtnQuellOrdner.Text = "📁 Ordner Wählen"
        Me.BtnQuellOrdner.UseVisualStyleBackColor = True
        '
        'LblZielPfad
        '
        Me.LblZielPfad.AutoSize = True
        Me.LblZielPfad.BackColor = System.Drawing.Color.Gray
        Me.LblZielPfad.Font = New System.Drawing.Font("Bahnschrift", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblZielPfad.Location = New System.Drawing.Point(248, 54)
        Me.LblZielPfad.Name = "LblZielPfad"
        Me.LblZielPfad.Size = New System.Drawing.Size(68, 16)
        Me.LblZielPfad.TabIndex = 3
        Me.LblZielPfad.Text = "Zielordner"
        '
        'TxtZielPfad
        '
        Me.TxtZielPfad.AllowDrop = True
        Me.TxtZielPfad.Location = New System.Drawing.Point(10, 73)
        Me.TxtZielPfad.Name = "TxtZielPfad"
        Me.TxtZielPfad.ReadOnly = True
        Me.TxtZielPfad.Size = New System.Drawing.Size(511, 23)
        Me.TxtZielPfad.TabIndex = 4
        '
        'BtnZielOrdner
        '
        Me.BtnZielOrdner.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnZielOrdner.Location = New System.Drawing.Point(527, 73)
        Me.BtnZielOrdner.Name = "BtnZielOrdner"
        Me.BtnZielOrdner.Size = New System.Drawing.Size(100, 23)
        Me.BtnZielOrdner.TabIndex = 5
        Me.BtnZielOrdner.Text = "📁 Ordner Wählen"
        Me.BtnZielOrdner.UseVisualStyleBackColor = True
        '
        'LblQuellStatus
        '
        Me.LblQuellStatus.AutoSize = True
        Me.LblQuellStatus.Location = New System.Drawing.Point(115, 99)
        Me.LblQuellStatus.Name = "LblQuellStatus"
        Me.LblQuellStatus.Size = New System.Drawing.Size(80, 16)
        Me.LblQuellStatus.TabIndex = 6
        Me.LblQuellStatus.Text = "❌ Wähle Ordner"
        '
        'LblZielStatus
        '
        Me.LblZielStatus.AutoSize = True
        Me.LblZielStatus.Location = New System.Drawing.Point(424, 99)
        Me.LblZielStatus.Name = "LblZielStatus"
        Me.LblZielStatus.Size = New System.Drawing.Size(80, 16)
        Me.LblZielStatus.TabIndex = 7
        Me.LblZielStatus.Text = "❌ Wähle Ordner"
        '
        'BtnVerschieben
        '
        Me.BtnVerschieben.BackColor = System.Drawing.Color.SandyBrown
        Me.BtnVerschieben.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnVerschieben.Location = New System.Drawing.Point(10, 226)
        Me.BtnVerschieben.Name = "BtnVerschieben"
        Me.BtnVerschieben.Size = New System.Drawing.Size(200, 40)
        Me.BtnVerschieben.TabIndex = 8
        Me.BtnVerschieben.Text = "🚀 VERSCHIEBEN"
        Me.BtnVerschieben.UseVisualStyleBackColor = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(10, 177)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(617, 23)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 9
        '
        'LblStatus
        '
        Me.LblStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblStatus.BackColor = System.Drawing.Color.DimGray
        Me.LblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStatus.Location = New System.Drawing.Point(10, 144)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(617, 30)
        Me.LblStatus.TabIndex = 10
        Me.LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'BtnKopieren
        '
        Me.BtnKopieren.BackColor = System.Drawing.Color.SkyBlue
        Me.BtnKopieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnKopieren.Location = New System.Drawing.Point(427, 226)
        Me.BtnKopieren.Name = "BtnKopieren"
        Me.BtnKopieren.Size = New System.Drawing.Size(200, 40)
        Me.BtnKopieren.TabIndex = 11
        Me.BtnKopieren.Text = "📋 KOPIEREN"
        Me.BtnKopieren.UseVisualStyleBackColor = False
        '
        'BtnPause
        '
        Me.BtnPause.BackColor = System.Drawing.Color.Silver
        Me.BtnPause.Enabled = False
        Me.BtnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPause.Location = New System.Drawing.Point(216, 226)
        Me.BtnPause.Name = "BtnPause"
        Me.BtnPause.Size = New System.Drawing.Size(100, 40)
        Me.BtnPause.TabIndex = 12
        Me.BtnPause.Text = "⏸️ PAUSE"
        Me.BtnPause.UseVisualStyleBackColor = False
        '
        'BtnAbbrechen
        '
        Me.BtnAbbrechen.BackColor = System.Drawing.Color.Silver
        Me.BtnAbbrechen.Enabled = False
        Me.BtnAbbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAbbrechen.Location = New System.Drawing.Point(322, 226)
        Me.BtnAbbrechen.Name = "BtnAbbrechen"
        Me.BtnAbbrechen.Size = New System.Drawing.Size(100, 40)
        Me.BtnAbbrechen.TabIndex = 13
        Me.BtnAbbrechen.Text = "⏹️ ABBRUCH"
        Me.BtnAbbrechen.UseVisualStyleBackColor = False
        '
        'PanelLog
        '
        Me.PanelLog.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelLog.Controls.Add(Me.ListLog)
        Me.PanelLog.Location = New System.Drawing.Point(10, 317)
        Me.PanelLog.Name = "PanelLog"
        Me.PanelLog.Size = New System.Drawing.Size(617, 141)
        Me.PanelLog.TabIndex = 14
        Me.PanelLog.Visible = False
        '
        'ListLog
        '
        Me.ListLog.BackColor = System.Drawing.SystemColors.MenuText
        Me.ListLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListLog.ForeColor = System.Drawing.Color.Red
        Me.ListLog.FormattingEnabled = True
        Me.ListLog.ItemHeight = 16
        Me.ListLog.Location = New System.Drawing.Point(0, 0)
        Me.ListLog.Name = "ListLog"
        Me.ListLog.Size = New System.Drawing.Size(617, 141)
        Me.ListLog.TabIndex = 0
        '
        'BtnLog
        '
        Me.BtnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLog.Font = New System.Drawing.Font("Bahnschrift Condensed", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLog.Location = New System.Drawing.Point(10, 272)
        Me.BtnLog.Name = "BtnLog"
        Me.BtnLog.Size = New System.Drawing.Size(617, 40)
        Me.BtnLog.TabIndex = 15
        Me.BtnLog.Text = "Log anzeigen"
        Me.BtnLog.UseVisualStyleBackColor = True
        '
        'TxtProfileName
        '
        Me.TxtProfileName.AllowDrop = True
        Me.TxtProfileName.Location = New System.Drawing.Point(10, 117)
        Me.TxtProfileName.Name = "TxtProfileName"
        Me.TxtProfileName.Size = New System.Drawing.Size(265, 23)
        Me.TxtProfileName.TabIndex = 16
        Me.TxtProfileName.Text = "Profilname"
        '
        'CmbProfile
        '
        Me.CmbProfile.FormattingEnabled = True
        Me.CmbProfile.Location = New System.Drawing.Point(493, 117)
        Me.CmbProfile.Name = "CmbProfile"
        Me.CmbProfile.Size = New System.Drawing.Size(134, 24)
        Me.CmbProfile.TabIndex = 17
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(281, 118)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 23)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Profil Speichern"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BtnProfileDelete
        '
        Me.BtnProfileDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnProfileDelete.Location = New System.Drawing.Point(387, 118)
        Me.BtnProfileDelete.Name = "BtnProfileDelete"
        Me.BtnProfileDelete.Size = New System.Drawing.Size(100, 23)
        Me.BtnProfileDelete.TabIndex = 19
        Me.BtnProfileDelete.Text = "Profil Löschen"
        Me.BtnProfileDelete.UseVisualStyleBackColor = True
        '
        'RbKeine
        '
        Me.RbKeine.AutoSize = True
        Me.RbKeine.Location = New System.Drawing.Point(10, 206)
        Me.RbKeine.Name = "RbKeine"
        Me.RbKeine.Size = New System.Drawing.Size(79, 20)
        Me.RbKeine.TabIndex = 20
        Me.RbKeine.TabStop = True
        Me.RbKeine.Text = "Keine Aktion"
        Me.RbKeine.UseVisualStyleBackColor = True
        '
        'RbShutdown
        '
        Me.RbShutdown.AutoSize = True
        Me.RbShutdown.Location = New System.Drawing.Point(267, 206)
        Me.RbShutdown.Name = "RbShutdown"
        Me.RbShutdown.Size = New System.Drawing.Size(102, 20)
        Me.RbShutdown.TabIndex = 21
        Me.RbShutdown.TabStop = True
        Me.RbShutdown.Text = "PC herunterfahren"
        Me.RbShutdown.UseVisualStyleBackColor = True
        '
        'RbStandby
        '
        Me.RbStandby.AutoSize = True
        Me.RbStandby.Location = New System.Drawing.Point(498, 206)
        Me.RbStandby.Name = "RbStandby"
        Me.RbStandby.Size = New System.Drawing.Size(129, 20)
        Me.RbStandby.TabIndex = 22
        Me.RbStandby.TabStop = True
        Me.RbStandby.Text = "Standby / Energiesparen"
        Me.RbStandby.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(5.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(634, 470)
        Me.Controls.Add(Me.RbStandby)
        Me.Controls.Add(Me.RbShutdown)
        Me.Controls.Add(Me.RbKeine)
        Me.Controls.Add(Me.BtnProfileDelete)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CmbProfile)
        Me.Controls.Add(Me.TxtProfileName)
        Me.Controls.Add(Me.BtnLog)
        Me.Controls.Add(Me.PanelLog)
        Me.Controls.Add(Me.BtnAbbrechen)
        Me.Controls.Add(Me.BtnPause)
        Me.Controls.Add(Me.BtnKopieren)
        Me.Controls.Add(Me.LblStatus)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.BtnVerschieben)
        Me.Controls.Add(Me.LblZielStatus)
        Me.Controls.Add(Me.LblQuellStatus)
        Me.Controls.Add(Me.BtnZielOrdner)
        Me.Controls.Add(Me.TxtZielPfad)
        Me.Controls.Add(Me.LblZielPfad)
        Me.Controls.Add(Me.BtnQuellOrdner)
        Me.Controls.Add(Me.TxtQuellPfad)
        Me.Controls.Add(Me.LblQuellPfad)
        Me.Font = New System.Drawing.Font("Bahnschrift SemiBold Condensed", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FolderMover"
        Me.PanelLog.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblQuellPfad As Label
    Friend WithEvents TxtQuellPfad As TextBox
    Friend WithEvents BtnQuellOrdner As Button
    Friend WithEvents LblZielPfad As Label
    Friend WithEvents TxtZielPfad As TextBox
    Friend WithEvents BtnZielOrdner As Button
    Friend WithEvents LblQuellStatus As Label
    Friend WithEvents LblZielStatus As Label
    Friend WithEvents BtnVerschieben As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents LblStatus As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BtnKopieren As Button
    Friend WithEvents BtnPause As Button
    Friend WithEvents BtnAbbrechen As Button
    Friend WithEvents PanelLog As Panel
    Friend WithEvents ListLog As ListBox
    Friend WithEvents BtnLog As Button
    Friend WithEvents TxtProfileName As TextBox
    Friend WithEvents CmbProfile As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents BtnProfileDelete As Button
    Friend WithEvents RbKeine As RadioButton
    Friend WithEvents RbShutdown As RadioButton
    Friend WithEvents RbStandby As RadioButton
End Class
