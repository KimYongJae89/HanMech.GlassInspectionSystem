using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Camera
{
    public enum eCameraStatus
    {
        CAM_CONNECTION_SUCCESS,
        CAM_CONNECTION_ERR,
        CAM_NOT_FOUND,
        CAM_CONNECTION_FAIL_ALREADY_USED_CAM,
        CAM_CONNECTION_FAIL_SERIAL_NOT_EXIST,
        CAM_CONNECTION_FAIL_NOT_FOUND_CAM,
        CAM_CONNECTION_FAIL_CAM_NULL,
        CAM_CONNECTION_FAIL_INTERNAL_ERROR,
    };
}
