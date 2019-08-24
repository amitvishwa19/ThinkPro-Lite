Namespace vsg
    Public Class vsg

        Private UserProject As String
        Private UserProcess As String
        Private UserSubProcess As String
        Private UserEmplID As Integer = 708093
        Private UserID As String
        Private UserName As String

        Private WorkTime As Integer
        Private ActivityLoggerType As String
        Private BackupPath As String
        Private SysLockTime As Integer
        Private SysLockCheck As Boolean

        Private DT As DataTable



        Public Property User_Project() As String
            Get
                Return UserProject
            End Get
            Set(ByVal value As String)
                UserProject = value
            End Set
        End Property
        Public Property User_Process() As String
            Get
                Return UserProcess
            End Get
            Set(ByVal value As String)
                UserProcess = value
            End Set
        End Property
        Public Property User_SubProcess() As String
            Get
                Return UserSubProcess
            End Get
            Set(ByVal value As String)
                UserSubProcess = value
            End Set
        End Property
        Public Property User_EmplID() As String
            Get
                Return UserEmplID
            End Get
            Set(ByVal value As String)
                UserEmplID = value
            End Set
        End Property
        Public Property User_ID() As String
            Get
                Return UserID
            End Get
            Set(ByVal value As String)
                UserID = value
            End Set
        End Property
        Public Property User_Name() As String
            Get
                Return UserName
            End Get
            Set(ByVal value As String)
                UserName = value
            End Set
        End Property

        Public Property Work_Time() As String
            Get
                Return WorkTime
            End Get
            Set(ByVal value As String)
                WorkTime = value
            End Set
        End Property
        Public Property Activity_Logger_Type() As String
            Get
                Return ActivityLoggerType
            End Get
            Set(ByVal value As String)
                ActivityLoggerType = value
            End Set
        End Property
        Public Property Backup_Path() As String
            Get
                Return BackupPath
            End Get
            Set(ByVal value As String)
                BackupPath = value
            End Set
        End Property
        Public Property Sys_Lock_Time() As String
            Get
                Return SysLockTime
            End Get
            Set(ByVal value As String)
                SysLockTime = value
            End Set
        End Property
        Public Property Sys_Lock_Check() As String
            Get
                Return SysLockCheck
            End Get
            Set(ByVal value As String)
                SysLockCheck = value
            End Set
        End Property

        Public Property U_dt() As DataTable
            Get
                Return DT
            End Get
            Set(ByVal value As DataTable)
                DT = value
            End Set
        End Property





    End Class
End Namespace