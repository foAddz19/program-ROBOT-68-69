Imports System.IO
Imports System.Media
Imports System.Text
Imports System.Threading

Public Class Form1
    Dim sum As Decimal = 0
    Dim sum2 As Decimal = 0
    Dim five As Decimal = 5
    Dim ten As Decimal = 10
    Dim one_five As Decimal = 15
    Dim twenty As Integer = 20
    Dim t_five As Decimal = 25
    Dim forty As Integer = 40
    Dim status As Integer = 1
    Dim times As String = "00:00"

    Private stopwatch As New Stopwatch

    ' load form
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer3.Interval = 300
        Timer3.Start()
    End Sub

    ' time center 
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim elapsed As TimeSpan = stopwatch.Elapsed
        Label1.Text = String.Format("{0:00}:{1:00}", Math.Floor(elapsed.Minutes), elapsed.Seconds)
        times = Label1.Text

        Try
            ' เขียนเวลาไปยังไฟล์ time.txt
            File.WriteAllText("D:\score\time.txt", times)
        Catch ex As Exception
            ' ถ้าเขียนไม่สำเร็จเพราะไฟล์ถูกใช้ ให้ข้ามไป
        End Try

        ' เงื่อนไขหมดเวลา
        If times = "03:00" Then
            Timer1.Stop()
            Timer2.Stop()
            stopwatch.Stop()
            times = "03:00"

        ElseIf times = "02:49" Then
            Label1.ForeColor = Color.Red
            Try
                Dim player As New SoundPlayer("D:\SoundPlayer\videoplayback.wav")
                player.Play()
            Catch
                ' หากหาไฟล์เสียงไม่เจอ ให้ข้าม
            End Try
        End If
    End Sub

    ' Timer ที่ใช้เช็คไฟล์ start/reset จากเครื่องอื่น
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        ' ===== อ่าน start =====
        Dim startContent As String = SafeReadFile("D:\score\test_start.txt")
        If startContent = "1" Then
            Button1_Click(Nothing, Nothing)
        End If

        ' ===== อ่าน reset =====
        Dim resetContent As String = SafeReadFile("D:\score\reset.txt")
        If resetContent = "1" Then
            Button3_Click(Nothing, Nothing)
        End If
    End Sub

    ' start/stop
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Start" Then
            Timer1.Start()
            Timer2.Start()
            stopwatch.Start()

            Button1.BackColor = Color.Red
            Button1.Text = "Stop"
            Button3.Enabled = False

            SafeWriteFile("\\DESKTOP-KQSD4R8\score\test_start.txt", "3")
        Else
            Timer1.Stop()
            Timer2.Stop()
            stopwatch.Stop()

            Button1.BackColor = Color.Lime
            Button1.Text = "Start"
            Button3.Enabled = True

            SafeWriteFile("\\DESKTOP-KQSD4R8\score\test_start.txt", "4")
        End If
    End Sub

    ' ปุ่ม Reset จับเวลาและไฟล์
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        stopwatch.Reset()
        Label1.ForeColor = Color.Black
        Label1.Text = "00:00"
        times = "00:00"
        sum2 = 0
        status = 0

        SafeWriteFile("\\DESKTOP-KQSD4R8\score\test_start.txt", "0")
        SafeWriteFile("D:\score\time.txt", "00:00")
        SafeWriteFile("D:\score\reset.txt", "0")
    End Sub

    ' ============================
    ' Share file
    Private Function SafeReadFile(filePath As String) As String
        Try
            Using fs As New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                Using reader As New StreamReader(fs)
                    Return reader.ReadToEnd().Trim()
                End Using
            End Using
        Catch
            Return ""
        End Try
    End Function

    ' security read file
    Private Sub SafeWriteFile(filePath As String, content As String)
        Try
            File.WriteAllText(filePath, content)
        Catch

        End Try
    End Sub
End Class
