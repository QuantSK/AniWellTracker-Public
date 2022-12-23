Imports System.IO

Module ModMain
    Public WithEvents MyTextLib As New TextLibCompact
    Public WithEvents MyFileSys As New FileSystemEngine
    Public WithEvents MyImgProcessing As New CompactImgProcessing

    Public Const MinImageSize As Integer = 10
    Public Const MaxImageSize As Integer = 4000

    Public Image_Original As Bitmap
    Public Image_Binarized As Bitmap
    Public Image_RegionExtracted As Bitmap
    Public Image_RegionLabeled As Bitmap
    Public Image_OverlayOnOriginal As Bitmap

    Public SubfolderName_Rendered As String = "Rendered"

    Public Filename_ROI As String = "ROI.csv"
    Public Filename_BatchProcessLog As String = "Tracking_BatchProcessLog.csv"
    Public Filename_AbsoluteLocation As String = "Tracking_AbsoluteLocation.csv"
    Public Filename_RelativeLocation As String = "Tracking_RelativeLocation.csv"
    Public Filename_TravelDistance As String = "Tracking_TravelDistance.csv"
    Public Filename_TravelSpeed As String = "Tracking_TravelSpeed.csv"
    Public Filename_TravelDistance_TimeBlockMin As String = "Tracking_TravelDistance_TimeBlock0min.csv"
    Public Filename_TravelSpeed_TimeBlockMin As String = "Tracking_TravelSpeed_TimeBlock0min.csv"
    Public Filename_DistanceFromCenter As String = "Tracking_DistanceFromCenter.csv"
    Public Filename_CentralAngle As String = "Tracking_CentralAngle.csv"
    Public Filename_RotationAngle As String = "Tracking_RotationAngle.csv"
    Public Filename_LocationHeatmap As String = "Tracking_LocationHeatmap.csv"
    Public Filename_DistanceFromCenterHeatmap As String = "Tracking_DistanceFromCenterHeatmap.csv"


    Public PathDelimit As String = Path.DirectorySeparatorChar


    'Array_.....: Index begins from 1
    Public Array_AbsoluteLocation(,) As String
    Public Array_RelativeLocation(,) As String
    Public Array_TravelDistance(,) As String
    Public Array_TravelSpeed(,) As String
    Public Array_TravelSpeed_EveryMin(,) As String
    Public Array_TravelDistance_EveryMin(,) As String
    Public Array_DistanceFromCenter(,) As String
    Public Array_CentralAngle(,) As String
    Public Array_Rotation(,) As String
    Public DistanceHeatmap(,) As String
    Public Structure Type_LocationHeatmap
        Dim LocationHeatmap(,) As Single
    End Structure

    'Array_LocationHeatmap: Index begins from 0
    Public Array_LocationHeatmap() As Type_LocationHeatmap


    Public Structure Type_ROI
        Dim Condition1 As String
        Dim Condition2 As String
        Dim TestDate As String
        Dim Plate As String
        Dim Well As String
        Dim Shape As String
        Dim Boundary As Rectangle
    End Structure

    Public ROI() As Type_ROI



    Public LocationHeatmap_GridSizeN As Integer = 15
    Public DistanceHeatmap_GridSizeN As Integer = 15

    Public BatchProcessLogfile As StreamWriter

    Public IsStopProcessing As Boolean = False

    Public GraphBox As Graphics


    'Return 0 if next proper image not found
    Public Function Find_NextImageIndex(ByRef SrcFileListBox As FileListBox, CurrentFileIndex As Integer,
                            TimeIntervalInSec As Long, IsWithFixedInterval As Boolean) As Integer




        Dim ImageCount As Long
        Dim TimeLapseMS As Long

        ImageCount = SrcFileListBox.FilesCount

        If IsWithFixedInterval = False Then
            If CurrentFileIndex + 1 <= ImageCount - 1 Then
                Return CurrentFileIndex + 1
            Else
                Return 0
            End If
        End If



        For q = CurrentFileIndex + 1 To ImageCount - 1
            TimeLapseMS = MyTextLib.Compute_TimeDiffInMS(
                                    SrcFileListBox.FileName(CurrentFileIndex),
                                   SrcFileListBox.FileName(CInt(q)))

            If TimeIntervalInSec < 60 Then
                If TimeLapseMS > (TimeIntervalInSec - 0.4) * 1000 AndAlso
                                TimeLapseMS < (TimeIntervalInSec + 0.4) * 1000 Then
                    Return CInt(q)
                End If
                Continue For
            End If

            'otherwise
            If TimeLapseMS > (TimeIntervalInSec - 1) * 1000 AndAlso
                                TimeLapseMS < (TimeIntervalInSec + 1) * 1000 Then
                Return CInt(q)
            End If



            'otherwise


        Next

        Return 0
    End Function


    Public Sub LoadWithoutShow(SrcForm As Form)
        SrcForm.WindowState = FormWindowState.Minimized
        SrcForm.Show()
        SrcForm.Hide()
    End Sub

    Public Function Get_AngleInDegreeOfTwoPoints(ByVal Point1 As Point, ByVal Point2 As Point) As Double
        Dim AngleInDegree As Double

        AngleInDegree = AngleInRadian_To_Degree(Get_AngleInRadianOfTwoPoints(Point1, Point2))
        AngleInDegree -= 90
        If AngleInDegree < 0 Then
            AngleInDegree = (AngleInDegree + 360) Mod 360
        End If


        Return AngleInDegree
    End Function


    Public Function AngleInRadian_To_Degree(ByVal AngleInRadian As Double) As Double
        Return AngleInRadian * 180 / Math.PI
    End Function


    Public Function Get_AngleInRadianOfTwoPoints(ByVal Point1 As Point, ByVal Point2 As Point) As Double
        Dim Vector As Point
        Dim AngleInDegree As Double

        Vector.X = Point2.X - Point1.X
        Vector.Y = Point2.Y - Point1.Y


        AngleInDegree = Math.Atan2(Vector.X, Vector.Y)

        Return AngleInDegree
    End Function


    Public Function Distance(ByVal X1 As Double, ByVal Y1 As Double,
                             ByVal X2 As Double, ByVal Y2 As Double) As Double
        Dim R As Double

        R = Math.Sqrt((X2 - X1) ^ 2 + (Y2 - Y1) ^ 2)

        Return R
    End Function


    Public Function Get_ChemicalInfoStr(ChemicalIndex As Integer,
                                        IsIncludeDate As Boolean,
                                        Optional IDSeperator As String = "|") As String
        Dim RetStr As String

        RetStr = ROI(ChemicalIndex).Condition1 + IDSeperator +
                     ROI(ChemicalIndex).Condition2



        RetStr &= IDSeperator & "P" & ROI(ChemicalIndex).Plate
        RetStr &= IDSeperator & "W" & ROI(ChemicalIndex).Well


        If IsIncludeDate Then
            RetStr &= "|" +
                     ROI(ChemicalIndex).TestDate
        End If


        Return RetStr
    End Function

End Module
