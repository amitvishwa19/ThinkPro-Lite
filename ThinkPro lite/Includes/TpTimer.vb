Namespace TpTimer

    Module TpTimer

        Public ActivityTimer As Double = Nothing
        Public BreakTimer As Double = Nothing
        Public LockTimer As Double = Nothing
        Public SwitchTimer As Double = Nothing


        Function activity_timer()
            ActivityTimer = 0
            Dim tmr As New Timer
            tmr.Interval = 1000
            tmr.Stop()
            tmr.Start()
            AddHandler tmr.Tick, AddressOf activity_timer_Tick
            Return True
        End Function

        Function activity_timer_Tick()
            ActivityTimer += 1
            BreakTimer += 1
            LockTimer += 1
            SwitchTimer += 1

            Dim iSpan As TimeSpan = TimeSpan.FromSeconds(ActivityTimer)


            Return ActivityTimer
        End Function



























    End Module
End Namespace

