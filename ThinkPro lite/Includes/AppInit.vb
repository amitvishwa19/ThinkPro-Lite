Imports System.IO
Namespace AppInit
    Module AppInit


        Public Function application_initialization()
            If app_init_config_file() = True Then
                If app_config_file_data_check() = True Then
                    db_details_to_settings()
                    Return True
                Else
                    If desktop_config_file_check() = True Then
                        If desktop_config_file_data_check() = True Then
                            If config_file_data_copy() = True Then
                                db_details_to_settings()
                                Return True
                            Else
                                Return False
                            End If
                        Else
                            Return False
                        End If
                    Else
                        Return False
                    End If

                End If
            End If
            Return False
        End Function


        'This will check if configuration folde is avaliable or not, if not avaliab;e then it wil create application folder and appconfig file
        Public Function app_init_config_file()
            Dim FolderPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ThinkPro"
            Dim FileName As String = FolderPath & "\Appconfig.txt"
            If Not System.IO.File.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ThinkPro" & "\AppConfig.txt") Then
                System.IO.Directory.CreateDirectory(FolderPath)
                File.Create(FileName).Dispose()
                Return True
            Else
                Return True
            End If
        End Function

        'This will check if data is avaliable in config file in app folder
        Public Function app_config_file_data_check()
            Try
                Dim enc As New Encryption
                Dim lines() As String = System.IO.File.ReadAllLines(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ThinkPro\AppConfig.txt")
                Dim DatabaseType As String = enc.decrypt(lines(0))
                Dim DatabaseName As String = enc.decrypt(lines(1))
                Dim ServerAddress As String = enc.decrypt(lines(2))
                Dim ServerPort As String = enc.decrypt(lines(3))
                Dim DatabaseID As String = enc.decrypt(lines(4))
                Dim DatabasePass As String = enc.decrypt(lines(5))
                Return True

                'Dim DbDetails As String = "PostgreSQL" & "," & DatabaseName & "," & ServerAddress & "," & ServerPort & "," & DatabaseID & "," & DatabasePass
                'My.Settings.ConnDetails = DbDetails
                'My.Settings.Save()

            Catch ex As IO.IOException
                Return False
            End Try
        End Function

        'This will check idf config file is avaliable on desktop or not
        Public Function desktop_config_file_check()
            If Not System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\AppConfig.txt") Then
                Return False
            Else
                Return True
            End If
        End Function

        'This will check if data is avaliable in desktop config file in app folder
        Public Function desktop_config_file_data_check()
            Try
                Dim enc As New Encryption
                Dim lines() As String = System.IO.File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\AppConfig.txt")
                Dim DatabaseType As String = enc.decrypt(lines(0))
                Dim DatabaseName As String = enc.decrypt(lines(1))
                Dim ServerAddress As String = enc.decrypt(lines(2))
                Dim ServerPort As String = enc.decrypt(lines(3))
                Dim DatabaseID As String = enc.decrypt(lines(4))
                Dim DatabasePass As String = enc.decrypt(lines(5))
                Return True

                'Dim DbDetails As String = "PostgreSQL" & "," & DatabaseName & "," & ServerAddress & "," & ServerPort & "," & DatabaseID & "," & DatabasePass
                'My.Settings.ConnDetails = DbDetails
                'My.Settings.Save()

            Catch ex As IO.IOException
                Return False
            End Try
        End Function

        'This will copy the data of config file from desktop file to app folde conf file
        Public Function config_file_data_copy()
            Try
                'Read Conf File
                Dim enc As New Encryption
                Dim lines() As String = System.IO.File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\AppConfig.txt")
                Dim DatabaseType As String = Crypto.decrypt(lines(0))
                Dim DatabaseName As String = Crypto.decrypt(lines(1))
                Dim ServerAddress As String = Crypto.decrypt(lines(2))
                Dim ServerPort As String = Crypto.decrypt(lines(3))
                Dim DatabaseID As String = Crypto.decrypt(lines(4))
                Dim DatabasePass As String = Crypto.decrypt(lines(5))

                Dim i As Integer
                Dim aryText(6) As String

                aryText(0) = Crypto.Encrypt(DatabaseType)
                aryText(1) = Crypto.Encrypt(DatabaseName)
                aryText(2) = Crypto.Encrypt(ServerAddress)
                aryText(3) = Crypto.Encrypt(ServerPort)
                aryText(4) = Crypto.Encrypt(DatabaseID)
                aryText(5) = Crypto.Encrypt(DatabasePass)

                Dim objWriter As New System.IO.StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ThinkPro\AppConfig.txt", True)
                For i = 0 To 5
                    objWriter.WriteLine(aryText(i))
                Next
                objWriter.Close()

                Dim DbDetails As String = "PostgreSQL" & "," & DatabaseName & "," & ServerAddress & "," & ServerPort & "," & DatabaseID & "," & DatabasePass
                My.Settings.ConnDetails = DbDetails
                My.Settings.Save()
                Return True
            Catch ex As IO.IOException
                Return False
            End Try
            Return False
        End Function

        'This will save the DB details from config file to settings
        Function db_details_to_settings()

            Try

                Dim lines() As String = System.IO.File.ReadAllLines(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ThinkPro" & "\AppConfig.txt")
                Dim DatabaseType As String = Crypto.decrypt(lines(0))
                Dim DatabaseName As String = Crypto.decrypt(lines(1))
                Dim ServerAddress As String = Crypto.decrypt(lines(2))
                Dim ServerPort As String = Crypto.decrypt(lines(3))
                Dim DatabaseID As String = Crypto.decrypt(lines(4))
                Dim DatabasePass As String = Crypto.decrypt(lines(5))
                Dim DbDetails As String = "PostgreSQL" & "," & DatabaseName & "," & ServerAddress & "," & ServerPort & "," & DatabaseID & "," & DatabasePass
                My.Settings.ConnDetails = DbDetails
                My.Settings.Save()
                Return True
            Catch ex As IO.IOException
                Return False
            End Try
        End Function





    End Module
End Namespace

