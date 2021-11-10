Imports System
Imports System.IO
Imports System.Net
Imports System.Security
Imports System.Windows.Forms
Imports EngineSiO
Imports Microsoft.SharePoint.Client

Module Module1
    Sub Main()
        Console.WriteLine("Hello World!")


        Dim opf As New OpenFileDialog
        opf.Filter = "Pliki XLSX|*.xlsx"
        opf.Multiselect = True

        If opf.ShowDialog = DialogResult.OK Then
            Dim i As Integer = 1
            For Each filename In opf.FileNames
                tPrzesylkaType.UploadFile(1, filename, i, opf.FileNames.Count)
            Next
        End If

        Console.ReadLine()

    End Sub



End Module
