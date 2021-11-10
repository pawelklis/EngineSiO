Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging
Imports Newtonsoft.Json


Public Class ConvertCore


    Public Shared Function GenereteWorkerCode(Optional Lenght As Integer = 6) As String
        If Lenght < 3 Then Lenght = 3

        Dim utc As String = Now.ToFileTimeUtc
        ' add random alpha prefix to UNIX time stamp
        Dim sPrefix As String = ""
        Dim rdm As New Random()
        For i As Integer = 1 To 3 ' if you need more than 3 alpah random charachters adjust i length
            sPrefix &= ChrW(rdm.Next(65, 90))
        Next
        ' OR MsgBox("ID" & sPrefix & utc)
        ' code here to use result


        Return sPrefix & utc.Substring(utc.Length - (Lenght - 3), (Lenght - 3))
    End Function
    Public Shared Function datatableTojson(dt As DataTable, pat As String) As String


        Using wr As TextWriter = File.CreateText(pat)
            Dim ser As New JsonSerializer
            ser.Serialize(wr, dt)

        End Using


    End Function



    Public Shared Function csvToDatatable(ByVal filename As String, ByVal separator As String, Optional PomijajPierwszeWierszeIlosc As Integer = 0)
        Dim dt As New System.Data.DataTable
        Dim firstLine As Boolean = True
        If IO.File.Exists(filename) Then
            Using sr As New StreamReader(filename, System.Text.Encoding.GetEncoding(1250))
                Dim i As Integer = 1
                While Not sr.EndOfStream



                    If firstLine Then
                        If i > PomijajPierwszeWierszeIlosc Then
                            firstLine = False
                            Dim cols = sr.ReadLine.Split(separator)
                            For Each col In cols
                                dt.Columns.Add(New DataColumn(col, GetType(String)))
                            Next
                        Else
                            sr.ReadLine.Split(separator)
                        End If
                    Else
                        Dim data() As String = sr.ReadLine.Split(separator)
                        If data.Length > dt.Columns.Count Then dt.Columns.Add("col_" & dt.Columns.Count)
                        dt.Rows.Add(data.ToArray)
                    End If


                    i += 1
                End While
            End Using
        End If
        Return dt
    End Function

    Public Shared Function BooleanInteger(w As Boolean) As Integer
        If w = True Then
            Return 1
        Else
            Return False
        End If
    End Function
    Public Shared Function BooleanInteger(w As Integer) As Boolean
        If w = 1 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function ImagetoBase64(obrazek As Image) As String
        Dim myImage As System.Drawing.Image = DirectCast(obrazek, System.Drawing.Image)
        Dim st As New MemoryStream
        If IsNothing(obrazek) Then Return ""
        myImage.Save(st, ImageFormat.Png)
        Dim im As System.Drawing.Image = System.Drawing.Image.FromStream(st)
        Dim base64 As String = ImageToBase64String(im, ImageFormat.Png)


        Return base64
    End Function
    Public Shared Function Base64toImage(base64String As String) As System.Drawing.Image
        Try
            Dim imageBytes As Byte() = Convert.FromBase64String(base64String)
            Dim MS As MemoryStream = New MemoryStream(imageBytes, 0, imageBytes.Length)
            MS.Write(imageBytes, 0, imageBytes.Length)
            Dim Image As System.Drawing.Image = System.Drawing.Image.FromStream(MS, True)
            Return Image
        Catch ex As Exception
            ' Return My.Resources.appbar_image_broken
        End Try


    End Function
    Public Shared Function ImageToBase64String(ByVal image As System.Drawing.Image,
                                             ByVal imageFormat As ImageFormat)

        Using memStream As New MemoryStream

            image.Save(memStream, imageFormat)

            Dim result As String = Convert.ToBase64String(memStream.ToArray())

            memStream.Close()

            Return result

        End Using

    End Function
    Public Shared Function Obrazek_DO_Byte(img As Image) As Byte()



        Dim ms = New MemoryStream()
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg) ' Use appropriate format here
        Dim bytes = ms.ToArray()

        Return bytes

    End Function
    Public Shared Function Obrazek_Z_Byte(bajt As Byte()) As Image
        Dim Img As Image
        Try
            Dim pictureBytes As New MemoryStream(bajt)

            Try
                Img = Image.FromStream(pictureBytes)
            Catch ex As Exception

                Img = Nothing
            End Try



        Catch ex As Exception

            Img = Nothing
        End Try

        Return Img
    End Function
    ''' <summary>
    ''' zmiejsza obrazek do maksymalnie określonych rozmiarów
    ''' </summary>
    ''' <param name="img"></param>
    ''' <param name="MaxWidth"></param>
    ''' <param name="MaxHeight"></param>
    ''' <returns></returns>
    Public Shared Function ZmniejszObrazek(img As Image, MaxWidth As Integer, MaxHeight As Integer) As Image
        If IsNothing(img) Then Return Nothing
        Dim krawedzA As Integer = img.Width
        Dim krawedzB As Integer = img.Height

        Dim nowaA As Integer
        Dim nowaB As Integer
        If krawedzA > krawedzB Then
            'dluzsza A
            If krawedzA > MaxWidth Then
                nowaA = krawedzA
                nowaB = krawedzB
                Do Until nowaA <= MaxHeight
                    nowaA -= 1
                    nowaB -= 1

                Loop

                Return ResizeImage(img, nowaA, nowaB)

            End If
        Else
            'dluzsza B
            If krawedzB > MaxWidth Then
                nowaA = krawedzA
                nowaB = krawedzB
                Do Until nowaB >= MaxHeight
                    nowaA -= 1
                    nowaB -= 1

                Loop

                Return ResizeImage(img, nowaA, nowaB)

            End If




        End If
        Return img

    End Function
    Public Shared Function ResizeImage(ByVal InputImage As Image, Width As Integer, Height As Integer) As Image
        Return New Bitmap(InputImage, New Size(Width, Height))
    End Function

    Public Shared Function StringToBytes(ByVal str As String) As Byte()
        Return System.Text.Encoding.Unicode.GetBytes(str)
    End Function
    Public Shared Function BytesToString(ByVal bytes() As Byte) As String
        If IsNothing(bytes) Then Return ""
        Debug.Print(System.Text.Encoding.Unicode.GetString(bytes))
        Return System.Text.Encoding.Unicode.GetString(bytes)
    End Function
    Public Shared Function Format00(wal As String) As String

        If wal < 10 And wal > -1 Then wal = "0" & wal
        If wal < 0 And wal > -10 Then wal = "-0" & wal


        Return wal
    End Function
    ''' <summary>
    ''' zamienia polskie znaki na zwykłe ą na a itd
    ''' </summary>
    ''' <param name="s"></param>
    ''' <returns></returns>
    Public Shared Function ZnakiPL(s As String) As String

        s = s.ToLower.Replace("ą", "a")
        s = s.ToLower.Replace("ć", "c")
        s = s.ToLower.Replace("ę", "e")
        s = s.ToLower.Replace("ł", "l")
        s = s.ToLower.Replace("ń", "n")
        s = s.ToLower.Replace("ó", "o")
        s = s.ToLower.Replace("ź", "z")
        s = s.ToLower.Replace("ż", "z")
        s = s.ToLower.Replace("ś", "s")

        Return s

    End Function



End Class
