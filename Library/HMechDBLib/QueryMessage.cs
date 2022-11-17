using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMechDBLib
{
    public static class QueryMessage
    {
        public static string InsertResultTable = "INSERT INTO dbo.tblResult VALUES(@GlassID, @Result, @ImagePath, @Updated, @DftCount, @TotalCamCount, @ThumbnailRatio)";
        public static string InsertDefectTable = "INSERT INTO dbo.tblDefect VALUES(@PID, @CamNo, @DftType, @Updated, @RealPosX, @RealPosY, @BoundingPosX, @BoundingPosY, @BoundingWidth, @BoundingHeight, @Score, @InspectionType, @MergeTopOffset)";
        public static string InsertDailyTable = "INSERT INTO dbo.DailyInformation VALUES(@Updated, @OKCount, @NGCount, @WarningCount)";
        public static string SearchingAllByResultTable = "SELECT * FROM dbo.tblResult";
        public static string SearchingGlassIDByResultTable = "SELECT * FROM dbo.tblResult WHERE GlassID LIKE @GlassID";
        public static string SearchingDateByResultTable = "SELECT * FROM dbo.tblResult WHERE Updated BETWEEN @FromDate AND @ToDate";
        public static string GetCurrentPID = "SELECT IDENT_CURRENT('dbo.tblResult') PID";
        public static string SearchingAllByDefectTable = "SELECT * FROM dbo.tblDefect WHERE PID LIKE @PID";
        public static string SearchingDefectTypeByDefectTable = "SELECT * FROM dbo.tblDefect WHERE DftType LIKE @DefectType AND PID LIKE @PID";
        //public static string UpdateRealPos = "UPDATE dbo.tblDefect SET RealPosX = @RealPosX, RealPosY = @RealPosY WHERE CamNo = @CamNo";
        public static string DeleteBeforeDateByResultTable = "DELETE FROM dbo.tblResult WHERE Updated < @Date";
        public static string DeleteBeforeDateByDefectTable = "DELETE FROM dbo.tblDefect WHERE Updated < @Date";
        public static string DeleteBeforeDateByDailyTable = "DELETE FROM dbo.DailyInformation WHERE Updated < @Date";
        public static string SearchingDateCountByResultTable = "SELECT * FROM dbo.tblResult WHERE Updated BETWEEN CONVERT(varchar(8), @StartTime, 112) AND @EndTime";
        public static string SearchingDateByDailyTable = "SELECT * FROM dbo.DailyInformation WHERE Updated BETWEEN CONVERT(varchar(8), @StartTime, 112) AND @EndTime";
        public static string InsertDailyInformation = "INSERT INTO dbo.DailyInformation VALUES(@Time, @OKCount, @NGCount, @WarningCount)";
    }
}
