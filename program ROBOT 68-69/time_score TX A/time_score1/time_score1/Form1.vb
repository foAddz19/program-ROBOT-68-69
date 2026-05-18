Imports System.IO
Imports System.Text
Imports System.Threading

Public Class Form1
    Dim sum_1 As Decimal = 0
    Dim five_1 As Decimal = 5
    Dim ten_1 As Decimal = 10
    Dim t_five As Decimal = 15
    Dim twenty_1 As Integer = 20
    Dim twenty_five As Integer = 25
    Dim forty_1 As Integer = 40

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer3.Interval = 1000
        Timer3.Start()
    End Sub

    ' load form
    Private Sub loadtext()
        Try
            Dim timeText As String = File.ReadAllText("\\COM8\score\time.txt")
            Label4.Text = timeText
            Label4.Visible = True
        Catch ex As Exception
            MessageBox.Show("ไม่สามารถโหลดเวลาได้: " & ex.Message)
        End Try
    End Sub

    ' save score
    Private Sub SaveScore()
        Try
            Dim filepath As String = "\\DESKTOP-KQSD4R8\score\score_A.txt"
            Using writer As New StreamWriter(filepath, False, Encoding.UTF8)
                writer.WriteLine(sum_1.ToString())
            End Using
        Catch ex As Exception
            MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกคะแนน: " & ex.Message)
        End Try
    End Sub

    ' time write
    Private Function ReadTime() As String
        Try
            Return File.ReadAllText("\\DESKTOP-KQSD4R8\score\time.txt")
        Catch ex As Exception
            Return "00.00"   'set 00.00
        End Try
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        loadtext()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        sum_1 += five_1
        SaveScore()
        Label2.Text = sum_1
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        sum_1 += ten_1
        Label2.Text = sum_1
        SaveScore()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        sum_1 += t_five
        Label2.Text = sum_1
        SaveScore()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        sum_1 += forty_1
        Label2.Text = sum_1

        Dim currentTime As String = ReadTime()
        Label4.Text = currentTime
        Label4.Visible = True

        SaveScore()

        Try
            Dim filepath As String = "\\DESKTOP-KQSD4R8\score\time_shot_A.txt"
            Using writer As New StreamWriter(filepath, False, Encoding.UTF8)
                writer.WriteLine(currentTime)
            End Using
        Catch ex As Exception
            MessageBox.Show("ไม่สามารถบันทึกเวลายิงได้: " & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        sum_1 += forty_1
        Label2.Text = sum_1
        SaveScore()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        sum_1 -= ten_1
        Label2.Text = sum_1
        SaveScore()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        sum_1 += twenty_1
        Label2.Text = sum_1
        SaveScore()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        sum_1 += twenty_five
        Label2.Text = sum_1
        SaveScore()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        sum_1 -= five_1
        Label2.Text = sum_1
        SaveScore()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        sum_1 = 0
        Label2.Text = 0
        Label4.Text = "00:00"
        Label4.Visible = False
        SaveScore()

        Try
            Dim filepath As String = "\\DESKTOP-KQSD4R8\score\time_shot_A.txt"
            Using writer As New StreamWriter(filepath, False, Encoding.UTF8)
                ' reset time shot "00:00"
                writer.WriteLine("")
            End Using
        Catch ex As Exception
            MessageBox.Show("ไม่สามารถรีเซ็ตเวลาได้: " & ex.Message)
        End Try
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Try
            Dim filepath As String = "\\DESKTOP-KQSD4R8\score\reset.txt"
            Using writer As New StreamWriter(filepath, False, Encoding.UTF8)
                writer.Write("1")
            End Using
        Catch ex As Exception
            MessageBox.Show("ไม่สามารถเขียน reset ได้: " & ex.Message)
        End Try
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Try
            Dim filepath As String = "\\DESKTOP-KQSD4R8\score\test_start.txt"
            Using writer As New StreamWriter(filepath, False, Encoding.UTF8)
                writer.Write("1")
            End Using

            If Button13.Text = "Start" Then
                Button13.BackColor = Color.Red
                Button13.Text = "Stop"
                Button12.Enabled = False
            Else
                Button13.BackColor = Color.Lime
                Button13.Text = "Start"
                Button12.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show("ไม่สามารถสั่ง Start/Stop ได้: " & ex.Message)
        End Try
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Try
            Dim content As String = File.ReadAllText("\\DESKTOP-KQSD4R8\score\test_start.txt")
            If content = "3" Then
                Button13.BackColor = Color.Red
                Button13.Text = "Stop"
                Button12.Enabled = False
            Else
                Button13.BackColor = Color.Lime
                Button13.Text = "Start"
                Button12.Enabled = True
            End If
        Catch ex As Exception
            ' อาจไม่แจ้ง error ทุกวินาที
        End Try
    End Sub
End Class
