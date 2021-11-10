Imports System.Text
Imports System.Windows.Forms
Imports EngineSiO
Imports EngineSiO.MongoDBQuery
Imports MongoDB.Bson
Imports MongoDB.Driver

Module Module1

    Sub Main()



St:
        Console.WriteLine("tf - import terminowości faz do mongoDB")
        Console.WriteLine("test - test mongodbreportcore")

        Dim a = Console.ReadLine
        If a = "tf" Then tf()
        If a = "test" Then test()


        Console.ReadLine()
        GoTo St

    End Sub

    Sub tf()
        Dim opf As New OpenFileDialog
        opf.Filter = "Pliki XLSX|*.xlsx"
        opf.Multiselect = True
        'Console.WriteLine("numer tygodnia:")
        'Dim tydzien As Integer = Console.ReadLine
        'Console.WriteLine("rok:")
        'Dim rok As Integer = Console.ReadLine



        If opf.ShowDialog = DialogResult.OK Then
            Dim i As Integer = 1

            tPrzesylkaType.UploadFile(1, opf.FileNames)

        End If




    End Sub
    Sub test()

        Dim opf As New OpenFileDialog
        opf.Filter = "Pliki XLSX|*.xlsx"
        opf.Multiselect = True
        'Console.WriteLine("numer tygodnia:")
        'Dim tydzien As Integer = Console.ReadLine
        'Console.WriteLine("rok:")
        'Dim rok As Integer = Console.ReadLine



        If opf.ShowDialog = DialogResult.OK Then
            Dim i As Integer = 1

            tPrzesylkaType.UploadFileRegionType(1, opf.FileNames)

        End If

    End Sub


    Sub kursimport()
        mongoDBCore.drop("kursymatryca")

        kursType.Import()



        Dim o = kursType.Load("50900")


        Debug.Print(o.Count)
    End Sub

End Module
