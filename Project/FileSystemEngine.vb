Imports System.IO

Public Class FileSystemEngine

    Public FolderPathArrayMax As Integer = 50000
    Public FolderPathArrayCount As Integer
    Public FolderPathArray(FolderPathArrayMax) As String



    Public Function Get_AllSubFolders(ByVal FolderName As String) As String()

        ReDim FolderPathArray(FolderPathArrayMax)


        FolderPathArray(0) = FolderName

        FolderPathArrayCount = 1

        Call PopulateTreeView(FolderName)


        'Dim TempFolderPathArray(FolderPathArrayCount - 1) As String
        'Array.Copy(FolderPathArray, TempFolderPathArray, FolderPathArrayCount - 2)

        ReDim Preserve FolderPathArray(FolderPathArrayCount - 1)

        Return FolderPathArray

    End Function


    Public Sub PopulateTreeView(ByVal FullPathName As String)

        Try

            Dim FulPathArray As String() =
                            Directory.GetDirectories(FullPathName)


            If FulPathArray.Length <> 0 Then
                Dim currentDirectory As String

                For Each currentDirectory In FulPathArray
                    FolderPathArrayCount += 1
                    If FolderPathArrayCount >= FolderPathArrayMax - 1 Then Exit Sub

                    FolderPathArray(FolderPathArrayCount - 1) = currentDirectory

                    PopulateTreeView(currentDirectory)
                Next

            Else

            End If

            Application.DoEvents()

        Catch Unauthorized As UnauthorizedAccessException
        End Try

    End Sub



    Public Function Get_OnlyPath_From_FullFileName(ByVal FullFileName As String) As String
        If FullFileName = "" Then Return ""

        Dim FileNameInfo As New IO.FileInfo(FullFileName)

        Return FileNameInfo.DirectoryName
    End Function


    Public Function Get_OnlyFileName_From_FullFileName(ByVal FullFileName As String) As String
        If FullFileName = "" Then Return ""

        Dim FileNameInfo As New IO.FileInfo(FullFileName)

        Return FileNameInfo.Name


    End Function


    Public Function FileExists(ByVal FileFullPath As String) As Boolean
        If FileFullPath = "" Then Return False

        Dim f As New IO.FileInfo(FileFullPath)
        Return f.Exists

    End Function


    Public Function FolderExists(ByVal FolderPath As String) As Boolean

        If FolderPath = "" Then Return False

        Dim f As New IO.DirectoryInfo(FolderPath)
        Return f.Exists

    End Function


    Public Sub MkDir(ByVal FolderPath As String)
        If Not Directory.Exists(FolderPath) Then
            Directory.CreateDirectory(FolderPath)
        End If
    End Sub


    Public Function Get_FilenameWithoutExtension_From_FullFileName(ByVal FullFileName As String) As String
        If FullFileName = "" Then Return ""

        Return System.IO.Path.GetFileNameWithoutExtension(
                    Get_OnlyFileName_From_FullFileName(FullFileName))
    End Function

    Public Function Get_FullFilenameWithoutExtension_From_FullFileName(ByVal FullFileName As String) As String
        If FullFileName = "" Then Return ""

        Return Get_OnlyPath_From_FullFileName(FullFileName) & PathDelimit &
               Get_FilenameWithoutExtension_From_FullFileName(FullFileName)
    End Function


    Public Sub DeleteMultipleFiles(ByVal DestFolder As String, ByVal FileStr As String)
        For Each FileFound As String In Directory.GetFiles(DestFolder, FileStr)
            File.Delete(FileFound)
        Next
    End Sub


    Public Sub BrowseFolder(FolderPath As String)
        Process.Start("explorer.exe", FolderPath)
    End Sub
End Class
