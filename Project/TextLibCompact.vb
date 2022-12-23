Public Class TextLibCompact

    Public Function Get_String2DAarry_From_LongString(ByVal SourceStr As String,
                                                      ByVal DelimitChar As String,
                                                      ByVal ExcludeEntireLineWhenNullCellDataFound As Boolean) As String(,)

        Dim RowCount As Integer, ColumnCount As Integer
        Dim LineArray(0) As String
        Dim ItemArray(0) As String
        Dim TableArray(0, 0) As String          'Actual data starts from (column index 1, row index 1)
        Dim Cur_Column, Cur_Row As Integer
        Dim EffectiveRowCount As Integer
        Dim Cur_EffectiveRow As Integer
        Dim IsNullCellDataFound As Boolean

        If SourceStr = "" Then Return Nothing



        'Split every line
        LineArray = Split(SourceStr, vbCrLf)
        RowCount = LineArray.GetUpperBound(0) + 1


        'Calculate effective line that doesn't have empty string
        EffectiveRowCount = 0
        For Cur_Row = 1 To RowCount
            If LineArray(Cur_Row - 1).Trim <> "" Then
                EffectiveRowCount += 1
            End If
        Next


        'Calculate column count
        ItemArray = Split(LineArray(0), DelimitChar)
        ColumnCount = ItemArray.GetUpperBound(0) + 1


        'Define dimension
        ReDim TableArray(ColumnCount, EffectiveRowCount)


        Cur_EffectiveRow = 1

        For Cur_Row = 1 To RowCount

            If LineArray(Cur_Row - 1).Trim <> "" Then
                ItemArray = Split(LineArray(Cur_Row - 1), DelimitChar)


                IsNullCellDataFound = False
                If ColumnCount <= ItemArray.GetUpperBound(0) + 1 Then
                    For Cur_Column = 1 To ColumnCount
                        TableArray(Cur_Column, Cur_EffectiveRow) = ItemArray(Cur_Column - 1).Trim
                        If TableArray(Cur_Column, Cur_EffectiveRow) = "" Then
                            IsNullCellDataFound = True
                        End If
                    Next
                Else
                    For Cur_Column = 1 To ItemArray.GetUpperBound(0) + 1
                        TableArray(Cur_Column, Cur_EffectiveRow) = ItemArray(Cur_Column - 1).Trim
                        If TableArray(Cur_Column, Cur_EffectiveRow) = "" Then
                            IsNullCellDataFound = True
                        End If
                    Next

                    For Cur_Column = ItemArray.GetUpperBound(0) + 2 To ColumnCount
                        TableArray(Cur_Column, Cur_EffectiveRow) = ""
                    Next
                End If



                If ExcludeEntireLineWhenNullCellDataFound And IsNullCellDataFound Then
                Else
                    Cur_EffectiveRow += 1
                End If

            End If
        Next


        If Cur_EffectiveRow = 1 Then Return Nothing



        ReDim Preserve TableArray(ColumnCount, Cur_EffectiveRow - 1)

        Return TableArray

    End Function


    Public Function Get_String2DAarry_From_TextFile(ByVal Par_Filename As String,
                                                    ByVal DelimitStr As String,
                                                    ByVal ExcludeEntireLineWhenNullCellDataFound As Boolean) As String(,)

        Dim Buf_String As String
        Dim Buf_Table(,) As String

        Try
            Buf_String = My.Computer.FileSystem.ReadAllText(Par_Filename)
            Buf_Table = Get_String2DAarry_From_LongString(Buf_String, DelimitStr, ExcludeEntireLineWhenNullCellDataFound)
        Catch
            Return Nothing
        End Try

        Return Buf_Table
    End Function


    'Sample StartTime/EndTime    2017-08-02 (13-49-00).PNG    or 2017-08-15 (13-53-41-173).PNG
    Function Compute_TimeDiffInMS(StartTime As String, EndTime As String) As Long
        Dim StartDate As Date
        Dim StartHour As Integer
        Dim StartMin As Integer
        Dim StartSec As Integer
        Dim StartMS As Integer

        Dim EndDate As Date
        Dim EndHour As Integer
        Dim EndMin As Integer
        Dim EndSec As Integer
        Dim EndMS As Integer

        Dim Diff_Day As Long
        Dim Diff_Hour As Long
        Dim Diff_Min As Long
        Dim Diff_Sec As Long
        Dim Diff_MS As Long

        Dim Diff_TotalMS As Long


        StartDate = DateValue(Left(StartTime, 10))
        StartHour = CInt(Mid(StartTime, 13, 2))
        StartMin = CInt(Mid(StartTime, 16, 2))
        StartSec = CInt(Mid(StartTime, 19, 2))
        If Mid(StartTime, 21, 1) = ")" Then
            StartMS = 0
        Else
            If Mid(StartTime, 21, 1) = "-" Then
                StartMS = CInt(Mid(StartTime, 22, 3))
            Else
                StartMS = CInt(Mid(StartTime, 21, 3))
            End If
        End If


        EndDate = DateValue(Left(EndTime, 10))
        EndHour = CInt(Mid(EndTime, 13, 2))
        EndMin = CInt(Mid(EndTime, 16, 2))
        EndSec = CInt(Mid(EndTime, 19, 2))
        If Mid(EndTime, 21, 1) = ")" Then
            EndMS = 0
        Else
            If Mid(EndTime, 21, 1) = "-" Then
                EndMS = CInt(Mid(EndTime, 22, 3))
            Else
                EndMS = CInt(Mid(EndTime, 21, 3))
            End If

        End If


        Diff_Day = DateDiff("d", StartDate, EndDate)
        Diff_Hour = EndHour - StartHour
        Diff_Min = EndMin - StartMin
        Diff_Sec = EndSec - StartSec
        Diff_MS = EndMS - StartMS

        Diff_TotalMS = Diff_Day * 24 * 60 * 60 * 1000 _
                        + Diff_Hour * 60 * 60 * 1000 _
                        + Diff_Min * 60 * 1000 _
                        + Diff_Sec * 1000 _
                        + Diff_MS

        Return Diff_TotalMS
    End Function

    Public Function Convert_String2DArray_To_LongString(String2DArray(,) As String,
                                                 delimitStr As String) As String
        Dim OutStr As New Text.StringBuilder
        Dim RowCountIndex, ColumnCountIndex As Integer
        Dim q, w As Integer

        ColumnCountIndex = String2DArray.GetUpperBound(0)
        RowCountIndex = String2DArray.GetUpperBound(1)

        For q = 1 To RowCountIndex
            For w = 1 To ColumnCountIndex - 1
                OutStr.Append(String2DArray(w, q) + delimitStr)
            Next
            OutStr.Append(String2DArray(ColumnCountIndex, q) + vbCrLf)
        Next

        Return OutStr.ToString
    End Function


    Public Function Convert_Int2DArray_To_LongString(Int2DArray(,) As Integer,
                                                 delimitStr As String) As String
        Dim OutStr As New Text.StringBuilder
        Dim RowCountIndex, ColumnCountIndex As Integer
        Dim q, w As Integer

        ColumnCountIndex = Int2DArray.GetUpperBound(0)
        RowCountIndex = Int2DArray.GetUpperBound(1)

        For q = 1 To RowCountIndex
            For w = 1 To ColumnCountIndex - 1
                OutStr.Append(Int2DArray(w, q).ToString + delimitStr)
            Next
            OutStr.Append(Int2DArray(ColumnCountIndex, q).ToString + vbCrLf)
        Next

        Return OutStr.ToString
    End Function


    Public Function RemoveRightChar(SourceStr As String, CharLength As Integer) As String
        Return Strings.Left(SourceStr, SourceStr.Length - CharLength)
    End Function
End Class
