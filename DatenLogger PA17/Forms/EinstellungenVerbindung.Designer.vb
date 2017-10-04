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
        Me.Bt_Schließen = New System.Windows.Forms.Button()
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
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.SPSBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ConnectionsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Connections = New DatenLogger_PA21.SPSConnections()
        Me.LoadSPS = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SPSNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConnectionTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SPSBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ConnectionsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Connections, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Bt_Schließen
        '
        Me.Bt_Schließen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_Schließen.Location = New System.Drawing.Point(479, 183)
        Me.Bt_Schließen.Name = "Bt_Schließen"
        Me.Bt_Schließen.Size = New System.Drawing.Size(81, 26)
        Me.Bt_Schließen.TabIndex = 10
        Me.Bt_Schließen.Text = "Schließen"
        Me.Bt_Schließen.UseVisualStyleBackColor = True
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
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView2.AutoGenerateColumns = False
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn, Me.SPSNameDataGridViewTextBoxColumn, Me.ConnectionTypeDataGridViewTextBoxColumn})
        Me.DataGridView2.DataSource = Me.SPSBindingSource1
        Me.DataGridView2.Location = New System.Drawing.Point(262, 12)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowTemplate.ReadOnly = True
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(298, 164)
        Me.DataGridView2.TabIndex = 12
        '
        'SPSBindingSource1
        '
        Me.SPSBindingSource1.DataMember = "SPS"
        Me.SPSBindingSource1.DataSource = Me.ConnectionsBindingSource
        '
        'ConnectionsBindingSource
        '
        Me.ConnectionsBindingSource.DataSource = Me.Connections
        Me.ConnectionsBindingSource.Position = 0
        '
        'Connections
        '
        Me.Connections.DataSetName = "Connections"
        Me.Connections.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LoadSPS
        '
        Me.LoadSPS.Location = New System.Drawing.Point(261, 183)
        Me.LoadSPS.Name = "LoadSPS"
        Me.LoadSPS.Size = New System.Drawing.Size(83, 27)
        Me.LoadSPS.TabIndex = 13
        Me.LoadSPS.Text = "Lade"
        Me.LoadSPS.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(350, 183)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(81, 26)
        Me.Button4.TabIndex = 14
        Me.Button4.Text = "Hinzufügen"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "id"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.Visible = False
        '
        'SPSNameDataGridViewTextBoxColumn
        '
        Me.SPSNameDataGridViewTextBoxColumn.DataPropertyName = "SPS_Name"
        Me.SPSNameDataGridViewTextBoxColumn.HeaderText = "SPS"
        Me.SPSNameDataGridViewTextBoxColumn.Name = "SPSNameDataGridViewTextBoxColumn"
        '
        'ConnectionTypeDataGridViewTextBoxColumn
        '
        Me.ConnectionTypeDataGridViewTextBoxColumn.DataPropertyName = "Connection_Type"
        Me.ConnectionTypeDataGridViewTextBoxColumn.HeaderText = "Verbindung"
        Me.ConnectionTypeDataGridViewTextBoxColumn.Name = "ConnectionTypeDataGridViewTextBoxColumn"
        '
        'EinstellungenVerbindung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 221)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.LoadSPS)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Bt_Schließen)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(300, 10)
        Me.Name = "EinstellungenVerbindung"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "EinstellungenVerbindung"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SPSBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ConnectionsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Connections, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Bt_Schließen As Button
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
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents LoadSPS As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Connections As SPSConnections
    Friend WithEvents SPSBindingSource1 As BindingSource
    Friend WithEvents ConnectionsBindingSource As BindingSource
    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SPSNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ConnectionTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
