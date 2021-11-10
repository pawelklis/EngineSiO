<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgf = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.pole = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.typ = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.val = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cx = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cy = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.dgf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgf)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1245, 256)
        Me.Panel1.TabIndex = 1
        '
        'dgf
        '
        Me.dgf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgf.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pole, Me.typ, Me.val, Me.cx, Me.cy})
        Me.dgf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgf.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgf.Location = New System.Drawing.Point(0, 0)
        Me.dgf.Name = "dgf"
        Me.dgf.Size = New System.Drawing.Size(1045, 256)
        Me.dgf.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.RichTextBox1)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(1045, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 256)
        Me.Panel2.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(87, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Label1"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(3, 41)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(194, 212)
        Me.RichTextBox1.TabIndex = 5
        Me.RichTextBox1.Text = ""
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Bottom
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(0, 693)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(1245, 300)
        Me.Chart1.TabIndex = 3
        Me.Chart1.Text = "Chart1"
        '
        'dg1
        '
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg1.Location = New System.Drawing.Point(0, 256)
        Me.dg1.Name = "dg1"
        Me.dg1.Size = New System.Drawing.Size(1245, 437)
        Me.dg1.TabIndex = 4
        '
        'pole
        '
        Me.pole.HeaderText = "pole"
        Me.pole.Items.AddRange(New Object() {"_id", "Dzien", "Nazwa_typu_przesylki", "Nazwa_serwisu", "swiadczenia", "Jednostki_fazy_Region", "Nazwa_jednostki", "Kod_jednostki", "PNI", "Nazwa_fazy", "Nazwa_rodzaju_fazy", "PNA_i_miejscowosc_adresata", "Identyfikator_przesylki", "Data_czas_nadania", "Gwarantowany_termin_doręczenia", "Planowy_data_czas_wejscia_Do_jednostki", "Rzeczywisty_data_czas_wejscia_Do_jednostki", "Planowy_data_czas_wyjscia_z_jednostki", "Rzeczywisty_data_czas_wyjscia_z_jednostki", "Terminowosc_fazy_dla_jednostki", "Terminowosc_E2E", "Sparametryzowana", "Data_czas_zdarzenia_konczacego_terminowosc_E2E", "idkarta", "ID_MRUMC_klienta", "Kod_klienta_w_ZST", "Nazwa_klienta", "klientkluczowy", "Nazwa_zdarzenia_wejscia", "Nazwa_zdarzenia_wyjscia", "kierunek", "tydzien", "idlok", "jnadania", "jnadaniakod", "jnadaniaPNA", "jnadaniakierunek", "jnadaniarozdzielnia", "kierunekdor", "pnador", "rozdzielniador", "godzinaWE", "godzinaWY", "czassobslminut", "NSTD", "OPZ"})
        Me.pole.Name = "pole"
        Me.pole.Width = 250
        '
        'typ
        '
        Me.typ.HeaderText = "typ"
        Me.typ.Items.AddRange(New Object() {"filtruj", "pokaz", "count", "sum"})
        Me.typ.Name = "typ"
        '
        'val
        '
        Me.val.HeaderText = "wartość"
        Me.val.Name = "val"
        '
        'cx
        '
        Me.cx.HeaderText = "x"
        Me.cx.Name = "cx"
        '
        'cy
        '
        Me.cy.HeaderText = "y"
        Me.cy.Name = "cy"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1245, 993)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dgf As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents dg1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents pole As DataGridViewComboBoxColumn
    Friend WithEvents typ As DataGridViewComboBoxColumn
    Friend WithEvents val As DataGridViewTextBoxColumn
    Friend WithEvents cx As DataGridViewCheckBoxColumn
    Friend WithEvents cy As DataGridViewCheckBoxColumn
End Class
