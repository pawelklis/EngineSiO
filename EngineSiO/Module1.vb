Imports EngineSiO.MongoDBQuery

Module Module1

    Sub Main()



        Dim ds As DataSet = xlsWorker.ExcelToDataset("C:\Users\klispawel\Downloads\PO - WER Komorniki.xlsx")

        For Each t As DataTable In ds.Tables
            t.Columns.Add("rejon")

            For i = 0 To t.Rows.Count - 1
                t.Rows(i)("rejon") = t.TableName
            Next

        Next

        Console.Clear()

        For Each t As DataTable In ds.Tables


            ConsoleTables.ConsoleTable.From(Of DataTable)(t).Write()

            Dim ct As New ConsoleTables.ConsoleTable("Miejscowość", "Ulica", "PNA", "rejon")





        Next




        Dim prog As New MongoDBReportsCore
        Dim dt As DataTable = MongoDBReportsCore.Harmonogram_Pracownik_LiczbaDni(2020, 11, 3)

        For i = 0 To dt.Columns.Count - 1
            Console.WriteLine(i & " " & dt.Columns(i).ColumnName)

        Next
        Console.WriteLine("Rows: " & dt.Rows.Count - 1)


        Console.Read()

    End Sub

End Module
