



Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet

Public Class xlsWorkerOpen

    Public Shared Event LoadProgress(current As Integer, all As Integer)
    Public Shared Function LoadFile(excelpath As String) As DataTable

        Dim rows As IEnumerable(Of List(Of String)) = ReadData(excelpath)
        Dim dt As DataTable = New DataTable()
        Dim firstRow As Boolean = True
        Dim cr As Integer = 0
        For Each rowData As List(Of String) In rows

            If firstRow Then

                For Each cell As String In rowData
                    dt.Columns.Add(cell)
                Next

                firstRow = False
            Else
                dt.Rows.Add()
                Dim i As Integer = 0

                For Each cell As String In rowData
                    dt.Rows(dt.Rows.Count - 1)(i) = cell
                    i += 1
                Next
            End If

            RaiseEvent LoadProgress(cr, rows.Count)
            Debug.Print(cr & " / " & rows.Count)
            cr += 1
        Next
        Return dt
    End Function

    Public Shared Iterator Function ReadData(ByVal fileName As String) As IEnumerable(Of List(Of String))
        Using spreadsheetDocument As SpreadsheetDocument = SpreadsheetDocument.Open(fileName, False)
            Dim workbookPart As WorkbookPart = spreadsheetDocument.WorkbookPart
            Dim worksheetPart As WorksheetPart = workbookPart.WorksheetParts.FirstOrDefault()
            Dim i As Integer = 0
            If workbookPart IsNot Nothing Then

                Using oxr As OpenXmlReader = OpenXmlReader.Create(worksheetPart)
                    Dim sharedStrings As IEnumerable(Of SharedStringItem) = workbookPart.SharedStringTablePart.SharedStringTable.Elements(Of SharedStringItem)()

                    While oxr.Read()

                        If oxr.ElementType = GetType(Row) Then
                            oxr.ReadFirstChild()
                            Dim rowData As List(Of String) = New List(Of String)()

                            Do

                                If oxr.ElementType = GetType(Cell) Then
                                    Dim c As Cell = CType(oxr.LoadCurrentElement(), Cell)
                                    Dim cellValue As String

                                    If c.DataType IsNot Nothing AndAlso CInt(c.DataType) = CellValues.SharedString Then
                                        Dim ssi As SharedStringItem = sharedStrings.ElementAt(Integer.Parse(c.CellValue.InnerText))
                                        cellValue = ssi.Text.Text
                                    Else
                                        cellValue = If(c.CellValue IsNot Nothing, c.CellValue.InnerText, "")
                                    End If

                                    rowData.Add(cellValue)
                                End If
                            Loop While oxr.ReadNextSibling()

                            Yield rowData
                        End If
                        'Debug.Print(i)
                        If i Mod 100 = 0 Then
                            RaiseEvent LoadProgress(i, 0)
                        End If



                        i += 1
                    End While
                End Using
            End If
        End Using
    End Function
End Class