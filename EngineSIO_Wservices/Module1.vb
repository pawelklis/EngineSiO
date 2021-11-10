Imports System
Imports System.IO
Imports System.Net
Imports System.Web.Services.Description
Imports Independentsoft.Share

Namespace Sample
    Class Module1
        Shared Sub Main(ByVal args As String())

            Try
                Dim service As New Service("https://independentsoft-my.sharepoint.com/personal/info_independentsoft_onmicrosoft_com", "info@independentsoft.onmicrosoft.com", "password")

                ''Increase timeout to 600000 milliseconds (10 minutes). Useful when downloading large files.
                ''Default value is 100000 (100 seconds).
                service.Timeout = 600000

                Dim inputStream = service.GetFileStream("/personal/info_independentsoft_onmicrosoft_com/Documents/Test.docx")

                Dim outputStream As New FileStream("e:\\Test.docx", FileMode.CreateNew)

                Using inputStream
                    Using outputStream

                        Dim buffer() As Byte = New Byte(8192) {}
                        Dim len As Integer = inputStream.Read(buffer, 0, buffer.Length)

                        While (len > 0)
                            outputStream.Write(buffer, 0, len)
                            len = inputStream.Read(buffer, 0, buffer.Length)
                        End While

                    End Using
                End Using

            Catch ex As WebException
                Console.WriteLine("Error: " + ex.Message)
                Console.Read()
            Catch ex As WebException
                Console.WriteLine("Error: " + ex.Message)
                Console.Read()
            End Try

        End Sub
    End Class
End Namespace