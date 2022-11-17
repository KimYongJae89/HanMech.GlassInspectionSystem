using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.PLC
{
    // PLC Type
    public enum ePLCType
    {
        None,
        Binary,
        ASCII,
    }

    public enum eResponseType
    {
        None,
        Read,
        Write,
        ParsingError_SubHeader,
        ParsingError_NetWorkNumber,
        ParsingError_PCNumber,
        ParsingError_ModuleIONumber,
        ParsingError_ModuleStationNumber,
        ParsingError_RequestDataLength,
        ParsingError_EndCode,
    }
    //// PLC Type
    public enum ePlcDataType
    {
        DEC,
        HEX,
    }

    public enum eResultConstant
    {
        NONE = 0,
        OK = 1,
        NG = 2,
        WARNING = 3,
    }

    public enum ePLCAddress
    {
        // Index와 PLC Property Setting값과 연관 있음.
        // Read : PLC -> PC
        PLC_HEARTBEAT = 0,
        PLC_DATETIME = 1,
        PLC_CV_DIRECTION = 2,
        PLC_REAL_VELOCITY = 3,
        PLC_TARGET_VELOCITY = 4,
        PLC_SLOW_VELOCITY = 5,
        PLC_GLASS_INPUT = 6,
        PLC_GLASS_ID = 7,
        PLC_GLASS_TYPE = 8,
        // Write : PC -> PLC
        PC_HEARTBEAT = 9,
        PC_INSPECTION_COMPLETE = 10,     // Inspection Complete : 0001
        PC_JUDGE = 11,                   // OK : 0001        NG : 0002           Warning : 0003
        PC_DEFECT_TYPE = 12,             // Broken : 0001    Chipping : 0010     Crack : 0100
    }
}
