<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EinstellungenVerbindung
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ConAttempts = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ReadCyc = New System.Windows.Forms.TextBox()
        Me.Watchdog_Bit = New System.Windows.Forms.TextBox()
        Me.Watchdog_Byte = New System.Windows.Forms.TextBox()
        Me.Watchdog_DB_Nr = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.MaskedIPBox = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Connections = New DatenLogger_PA21.Connections()
        Me.SPSParameterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IPDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TimeoutDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TimerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WatchdogDBDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WatchdogByteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WatchdogBitDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.SPSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LoadSPS = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.IdDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SPSNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConnectionTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Connections, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SPSParameterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SPSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.CheckFileExists = True
        Me.SaveFileDialog1.CreatePrompt = True
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(504, 313)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 24)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Schließen"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(123, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Verbindungsversuche:"
        '
        'ConAttempts
        '
        Me.ConAttempts.Location = New System.Drawing.Point(126, 139)
        Me.ConAttempts.Name = "ConAttempts"
        Me.ConAttempts.Size = New System.Drawing.Size(59, 20)
        Me.ConAttempts.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(74, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(20, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "ms"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Lesezyklus:"
        '
        'ReadCyc
        '
        Me.ReadCyc.Location = New System.Drawing.Point(9, 139)
        Me.ReadCyc.Name = "ReadCyc"
        Me.ReadCyc.Size = New System.Drawing.Size(59, 20)
        Me.ReadCyc.TabIndex = 15
        '
        'Watchdog_Bit
        '
        Me.Watchdog_Bit.Location = New System.Drawing.Point(198, 90)
        Me.Watchdog_Bit.Name = "Watchdog_Bit"
        Me.Watchdog_Bit.Size = New System.Drawing.Size(33, 20)
        Me.Watchdog_Bit.TabIndex = 14
        '
        'Watchdog_Byte
        '
        Me.Watchdog_Byte.Location = New System.Drawing.Point(126, 90)
        Me.Watchdog_Byte.Name = "Watchdog_Byte"
        Me.Watchdog_Byte.Size = New System.Drawing.Size(33, 20)
        Me.Watchdog_Byte.TabIndex = 13
        '
        'Watchdog_DB_Nr
        '
        Me.Watchdog_DB_Nr.Location = New System.Drawing.Point(39, 90)
        Me.Watchdog_DB_Nr.Name = "Watchdog_DB_Nr"
        Me.Watchdog_DB_Nr.Size = New System.Drawing.Size(33, 20)
        Me.Watchdog_DB_Nr.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(170, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Bit:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(89, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Byte:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "DB:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Watchdog Adresse:"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(9, 46)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(227, 13)
        Me.TextBox1.TabIndex = 7
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "Aktuelle IP:"
        '
        'MaskedIPBox
        '
        Me.MaskedIPBox.Location = New System.Drawing.Point(9, 23)
        Me.MaskedIPBox.Mask = "###/###/###/###"
        Me.MaskedIPBox.Name = "MaskedIPBox"
        Me.MaskedIPBox.Size = New System.Drawing.Size(90, 20)
        Me.MaskedIPBox.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.ConAttempts)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.ReadCyc)
        Me.GroupBox1.Controls.Add(Me.Watchdog_Bit)
        Me.GroupBox1.Controls.Add(Me.Watchdog_Byte)
        Me.GroupBox1.Controls.Add(Me.Watchdog_DB_Nr)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.MaskedIPBox)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(239, 165)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Verbindungseinstellung"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(111, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(53, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn, Me.NameDataGridViewTextBoxColumn, Me.IPDataGridViewTextBoxColumn, Me.TimeoutDataGridViewTextBoxColumn, Me.TimerDataGridViewTextBoxColumn, Me.WatchdogDBDataGridViewTextBoxColumn, Me.WatchdogByteDataGridViewTextBoxColumn, Me.WatchdogBitDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.SPSParameterBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(12, 226)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(568, 75)
        Me.DataGridView1.TabIndex = 11
        '
        'Connections
        '
        Me.Connections.DataSetName = "Connections"
        Me.Connections.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SPSParameterBindingSource
        '
        Me.SPSParameterBindingSource.DataMember = "SPS_Parameter"
        Me.SPSParameterBindingSource.DataSource = Me.Connections
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "id"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.Visible = False
        '
        'NameDataGridViewTextBoxColumn
        '
        Me.NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
        Me.NameDataGridViewTextBoxColumn.HeaderText = "Name"
        Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
        Me.NameDataGridViewTextBoxColumn.Visible = False
        '
        'IPDataGridViewTextBoxColumn
        '
        Me.IPDataGridViewTextBoxColumn.DataPropertyName = "IP"
        Me.IPDataGridViewTextBoxColumn.HeaderText = "IP"
        Me.IPDataGridViewTextBoxColumn.Name = "IPDataGridViewTextBoxColumn"
        '
        'TimeoutDataGridViewTextBoxColumn
        '
        Me.TimeoutDataGridViewTextBoxColumn.DataPropertyName = "Timeout"
        Me.TimeoutDataGridViewTextBoxColumn.HeaderText = "Timeout"
        Me.TimeoutDataGridViewTextBoxColumn.Name = "TimeoutDataGridViewTextBoxColumn"
        '
        'TimerDataGridViewTextBoxColumn
        '
        Me.TimerDataGridViewTextBoxColumn.DataPropertyName = "Timer"
        Me.TimerDataGridViewTextBoxColumn.HeaderText = "Timer"
        Me.TimerDataGridViewTextBoxColumn.Name = "TimerDataGridViewTextBoxColumn"
        '
        'WatchdogDBDataGridViewTextBoxColumn
        '
        Me.WatchdogDBDataGridViewTextBoxColumn.DataPropertyName = "Watchdog_DB"
        Me.WatchdogDBDataGridViewTextBoxColumn.HeaderText = "Watchdog_DB"
        Me.WatchdogDBDataGridViewTextBoxColumn.Name = "WatchdogDBDataGridViewTextBoxColumn"
        '
        'WatchdogByteDataGridViewTextBoxColumn
        '
        Me.WatchdogByteDataGridViewTextBoxColumn.DataPropertyName = "Watchdog_Byte"
        Me.WatchdogByteDataGridViewTextBoxColumn.HeaderText = "Watchdog_Byte"
        Me.WatchdogByteDataGridViewTextBoxColumn.Name = "WatchdogByteDataGridViewTextBoxColumn"
        '
        'WatchdogBitDataGridViewTextBoxColumn
        '
        Me.WatchdogBitDataGridViewTextBoxColumn.DataPropertyName = "Watchdog_Bit"
        Me.WatchdogBitDataGridViewTextBoxColumn.HeaderText = "Watchdog_Bit"
        Me.WatchdogBitDataGridViewTextBoxColumn.Name = "WatchdogBitDataGridViewTextBoxColumn"
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AutoGenerateColumns = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn1, Me.SPSNameDataGridViewTextBoxColumn, Me.ConnectionTypeDataGridViewTextBoxColumn})
        Me.DataGridView2.DataSource = Me.SPSBindingSource
        Me.DataGridView2.Location = New System.Drawing.Point(266, 12)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(318, 164)
        Me.DataGridView2.TabIndex = 12
        '
        'SPSBindingSource
        '
        Me.SPSBindingSource.DataMember = "SPS"
        Me.SPSBindingSource.DataSource = Me.Connections
        '
        'LoadSPS
        '
        Me.LoadSPS.Location = New System.Drawing.Point(410, 182)
        Me.LoadSPS.Name = "LoadSPS"
        Me.LoadSPS.Size = New System.Drawing.Size(83, 27)
        Me.LoadSPS.TabIndex = 13
        Me.LoadSPS.Text = "Lade"
        Me.LoadSPS.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(499, 182)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(81, 26)
        Me.Button4.TabIndex = 14
        Me.Button4.Text = "Hinzufügen"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'IdDataGridViewTextBoxColumn1
        '
        Me.IdDataGridViewTextBoxColumn1.DataPropertyName = "id"
        Me.IdDataGridViewTextBoxColumn1.HeaderText = "id"
        Me.IdDataGridViewTextBoxColumn1.Name = "IdDataGridViewTextBoxColumn1"
        Me.IdDataGridViewTextBoxColumn1.ReadOnly = True
        Me.IdDataGridViewTextBoxColumn1.Visible = False
        '
        'SPSNameDataGridViewTextBoxColumn
        '
        Me.SPSNameDataGridViewTextBoxColumn.DataPropertyName = "SPS_Name"
        Me.SPSNameDataGridViewTextBoxColumn.HeaderText = "SPS"
        Me.SPSNameDataGridViewTextBoxColumn.Name = "SPSNameDataGridViewTextBoxColumn"
        Me.SPSNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ConnectionTypeDataGridViewTextBoxColumn
        '
        Me.ConnectionTypeDataGridViewTextBoxColumn.DataPropertyName = "Connection_Type"
        Me.ConnectionTypeDataGridViewTextBoxColumn.HeaderText = "Verbindung"
        Me.ConnectionTypeDataGridViewTextBoxColumn.Name = "ConnectionTypeDataGridViewTextBoxColumn"
        Me.ConnectionTypeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'EinstellungenVerbindung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 345)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.LoadSPS)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(300, 300)
        Me.Name = "EinstellungenVerbindung"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "EinstellungenVerbindung"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Connections, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SPSParameterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SPSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Button2 As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents ConAttempts As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents ReadCyc As TextBox
    Friend WithEvents Watchdog_Bit As TextBox
    Friend WithEvents Watchdog_Byte As TextBox
    Friend WithEvents Watchdog_DB_Nr As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents MaskedIPBox As MaskedTextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IPDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TimeoutDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TimerDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents WatchdogDBDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents WatchdogByteDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents WatchdogBitDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SPSParameterBindingSource As BindingSource
    Friend WithEvents Connections As Connections
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents SPSBindingSource As BindingSource
    Friend WithEvents LoadSPS As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents IdDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents SPSNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ConnectionTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
