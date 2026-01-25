namespace NVAPIWrapper
{
    /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status"]/*' />
    public enum _NvAPI_Status
    {
        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_OK"]/*' />
        NVAPI_OK = 0,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_ERROR"]/*' />
        NVAPI_ERROR = -1,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_LIBRARY_NOT_FOUND"]/*' />
        NVAPI_LIBRARY_NOT_FOUND = -2,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_NO_IMPLEMENTATION"]/*' />
        NVAPI_NO_IMPLEMENTATION = -3,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_API_NOT_INITIALIZED"]/*' />
        NVAPI_API_NOT_INITIALIZED = -4,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INVALID_ARGUMENT"]/*' />
        NVAPI_INVALID_ARGUMENT = -5,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_NVIDIA_DEVICE_NOT_FOUND"]/*' />
        NVAPI_NVIDIA_DEVICE_NOT_FOUND = -6,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_END_ENUMERATION"]/*' />
        NVAPI_END_ENUMERATION = -7,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INVALID_HANDLE"]/*' />
        NVAPI_INVALID_HANDLE = -8,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INCOMPATIBLE_STRUCT_VERSION"]/*' />
        NVAPI_INCOMPATIBLE_STRUCT_VERSION = -9,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_HANDLE_INVALIDATED"]/*' />
        NVAPI_HANDLE_INVALIDATED = -10,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_OPENGL_CONTEXT_NOT_CURRENT"]/*' />
        NVAPI_OPENGL_CONTEXT_NOT_CURRENT = -11,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INVALID_POINTER"]/*' />
        NVAPI_INVALID_POINTER = -14,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_NO_GL_EXPERT"]/*' />
        NVAPI_NO_GL_EXPERT = -12,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INSTRUMENTATION_DISABLED"]/*' />
        NVAPI_INSTRUMENTATION_DISABLED = -13,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_NO_GL_NSIGHT"]/*' />
        NVAPI_NO_GL_NSIGHT = -15,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_EXPECTED_LOGICAL_GPU_HANDLE"]/*' />
        NVAPI_EXPECTED_LOGICAL_GPU_HANDLE = -100,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_EXPECTED_PHYSICAL_GPU_HANDLE"]/*' />
        NVAPI_EXPECTED_PHYSICAL_GPU_HANDLE = -101,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_EXPECTED_DISPLAY_HANDLE"]/*' />
        NVAPI_EXPECTED_DISPLAY_HANDLE = -102,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INVALID_COMBINATION"]/*' />
        NVAPI_INVALID_COMBINATION = -103,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_NOT_SUPPORTED"]/*' />
        NVAPI_NOT_SUPPORTED = -104,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_PORTID_NOT_FOUND"]/*' />
        NVAPI_PORTID_NOT_FOUND = -105,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_EXPECTED_UNATTACHED_DISPLAY_HANDLE"]/*' />
        NVAPI_EXPECTED_UNATTACHED_DISPLAY_HANDLE = -106,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INVALID_PERF_LEVEL"]/*' />
        NVAPI_INVALID_PERF_LEVEL = -107,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_DEVICE_BUSY"]/*' />
        NVAPI_DEVICE_BUSY = -108,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_NV_PERSIST_FILE_NOT_FOUND"]/*' />
        NVAPI_NV_PERSIST_FILE_NOT_FOUND = -109,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_PERSIST_DATA_NOT_FOUND"]/*' />
        NVAPI_PERSIST_DATA_NOT_FOUND = -110,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_EXPECTED_TV_DISPLAY"]/*' />
        NVAPI_EXPECTED_TV_DISPLAY = -111,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_EXPECTED_TV_DISPLAY_ON_DCONNECTOR"]/*' />
        NVAPI_EXPECTED_TV_DISPLAY_ON_DCONNECTOR = -112,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_NO_ACTIVE_SLI_TOPOLOGY"]/*' />
        NVAPI_NO_ACTIVE_SLI_TOPOLOGY = -113,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_SLI_RENDERING_MODE_NOTALLOWED"]/*' />
        NVAPI_SLI_RENDERING_MODE_NOTALLOWED = -114,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_EXPECTED_DIGITAL_FLAT_PANEL"]/*' />
        NVAPI_EXPECTED_DIGITAL_FLAT_PANEL = -115,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_ARGUMENT_EXCEED_MAX_SIZE"]/*' />
        NVAPI_ARGUMENT_EXCEED_MAX_SIZE = -116,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_DEVICE_SWITCHING_NOT_ALLOWED"]/*' />
        NVAPI_DEVICE_SWITCHING_NOT_ALLOWED = -117,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_TESTING_CLOCKS_NOT_SUPPORTED"]/*' />
        NVAPI_TESTING_CLOCKS_NOT_SUPPORTED = -118,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_UNKNOWN_UNDERSCAN_CONFIG"]/*' />
        NVAPI_UNKNOWN_UNDERSCAN_CONFIG = -119,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_TIMEOUT_RECONFIGURING_GPU_TOPO"]/*' />
        NVAPI_TIMEOUT_RECONFIGURING_GPU_TOPO = -120,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_DATA_NOT_FOUND"]/*' />
        NVAPI_DATA_NOT_FOUND = -121,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_EXPECTED_ANALOG_DISPLAY"]/*' />
        NVAPI_EXPECTED_ANALOG_DISPLAY = -122,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_NO_VIDLINK"]/*' />
        NVAPI_NO_VIDLINK = -123,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_REQUIRES_REBOOT"]/*' />
        NVAPI_REQUIRES_REBOOT = -124,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INVALID_HYBRID_MODE"]/*' />
        NVAPI_INVALID_HYBRID_MODE = -125,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_MIXED_TARGET_TYPES"]/*' />
        NVAPI_MIXED_TARGET_TYPES = -126,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_SYSWOW64_NOT_SUPPORTED"]/*' />
        NVAPI_SYSWOW64_NOT_SUPPORTED = -127,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_IMPLICIT_SET_GPU_TOPOLOGY_CHANGE_NOT_ALLOWED"]/*' />
        NVAPI_IMPLICIT_SET_GPU_TOPOLOGY_CHANGE_NOT_ALLOWED = -128,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_REQUEST_USER_TO_CLOSE_NON_MIGRATABLE_APPS"]/*' />
        NVAPI_REQUEST_USER_TO_CLOSE_NON_MIGRATABLE_APPS = -129,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_OUT_OF_MEMORY"]/*' />
        NVAPI_OUT_OF_MEMORY = -130,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_WAS_STILL_DRAWING"]/*' />
        NVAPI_WAS_STILL_DRAWING = -131,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_FILE_NOT_FOUND"]/*' />
        NVAPI_FILE_NOT_FOUND = -132,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_TOO_MANY_UNIQUE_STATE_OBJECTS"]/*' />
        NVAPI_TOO_MANY_UNIQUE_STATE_OBJECTS = -133,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INVALID_CALL"]/*' />
        NVAPI_INVALID_CALL = -134,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_D3D10_1_LIBRARY_NOT_FOUND"]/*' />
        NVAPI_D3D10_1_LIBRARY_NOT_FOUND = -135,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_FUNCTION_NOT_FOUND"]/*' />
        NVAPI_FUNCTION_NOT_FOUND = -136,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INVALID_USER_PRIVILEGE"]/*' />
        NVAPI_INVALID_USER_PRIVILEGE = -137,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_EXPECTED_NON_PRIMARY_DISPLAY_HANDLE"]/*' />
        NVAPI_EXPECTED_NON_PRIMARY_DISPLAY_HANDLE = -138,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_EXPECTED_COMPUTE_GPU_HANDLE"]/*' />
        NVAPI_EXPECTED_COMPUTE_GPU_HANDLE = -139,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_STEREO_NOT_INITIALIZED"]/*' />
        NVAPI_STEREO_NOT_INITIALIZED = -140,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_STEREO_REGISTRY_ACCESS_FAILED"]/*' />
        NVAPI_STEREO_REGISTRY_ACCESS_FAILED = -141,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_STEREO_REGISTRY_PROFILE_TYPE_NOT_SUPPORTED"]/*' />
        NVAPI_STEREO_REGISTRY_PROFILE_TYPE_NOT_SUPPORTED = -142,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_STEREO_REGISTRY_VALUE_NOT_SUPPORTED"]/*' />
        NVAPI_STEREO_REGISTRY_VALUE_NOT_SUPPORTED = -143,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_STEREO_NOT_ENABLED"]/*' />
        NVAPI_STEREO_NOT_ENABLED = -144,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_STEREO_NOT_TURNED_ON"]/*' />
        NVAPI_STEREO_NOT_TURNED_ON = -145,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_STEREO_INVALID_DEVICE_INTERFACE"]/*' />
        NVAPI_STEREO_INVALID_DEVICE_INTERFACE = -146,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_STEREO_PARAMETER_OUT_OF_RANGE"]/*' />
        NVAPI_STEREO_PARAMETER_OUT_OF_RANGE = -147,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_STEREO_FRUSTUM_ADJUST_MODE_NOT_SUPPORTED"]/*' />
        NVAPI_STEREO_FRUSTUM_ADJUST_MODE_NOT_SUPPORTED = -148,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_TOPO_NOT_POSSIBLE"]/*' />
        NVAPI_TOPO_NOT_POSSIBLE = -149,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_MODE_CHANGE_FAILED"]/*' />
        NVAPI_MODE_CHANGE_FAILED = -150,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_D3D11_LIBRARY_NOT_FOUND"]/*' />
        NVAPI_D3D11_LIBRARY_NOT_FOUND = -151,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INVALID_ADDRESS"]/*' />
        NVAPI_INVALID_ADDRESS = -152,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_STRING_TOO_SMALL"]/*' />
        NVAPI_STRING_TOO_SMALL = -153,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_MATCHING_DEVICE_NOT_FOUND"]/*' />
        NVAPI_MATCHING_DEVICE_NOT_FOUND = -154,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_DRIVER_RUNNING"]/*' />
        NVAPI_DRIVER_RUNNING = -155,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_DRIVER_NOTRUNNING"]/*' />
        NVAPI_DRIVER_NOTRUNNING = -156,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_ERROR_DRIVER_RELOAD_REQUIRED"]/*' />
        NVAPI_ERROR_DRIVER_RELOAD_REQUIRED = -157,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_SET_NOT_ALLOWED"]/*' />
        NVAPI_SET_NOT_ALLOWED = -158,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_ADVANCED_DISPLAY_TOPOLOGY_REQUIRED"]/*' />
        NVAPI_ADVANCED_DISPLAY_TOPOLOGY_REQUIRED = -159,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_SETTING_NOT_FOUND"]/*' />
        NVAPI_SETTING_NOT_FOUND = -160,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_SETTING_SIZE_TOO_LARGE"]/*' />
        NVAPI_SETTING_SIZE_TOO_LARGE = -161,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_TOO_MANY_SETTINGS_IN_PROFILE"]/*' />
        NVAPI_TOO_MANY_SETTINGS_IN_PROFILE = -162,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_PROFILE_NOT_FOUND"]/*' />
        NVAPI_PROFILE_NOT_FOUND = -163,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_PROFILE_NAME_IN_USE"]/*' />
        NVAPI_PROFILE_NAME_IN_USE = -164,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_PROFILE_NAME_EMPTY"]/*' />
        NVAPI_PROFILE_NAME_EMPTY = -165,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_EXECUTABLE_NOT_FOUND"]/*' />
        NVAPI_EXECUTABLE_NOT_FOUND = -166,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_EXECUTABLE_ALREADY_IN_USE"]/*' />
        NVAPI_EXECUTABLE_ALREADY_IN_USE = -167,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_DATATYPE_MISMATCH"]/*' />
        NVAPI_DATATYPE_MISMATCH = -168,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_PROFILE_REMOVED"]/*' />
        NVAPI_PROFILE_REMOVED = -169,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_UNREGISTERED_RESOURCE"]/*' />
        NVAPI_UNREGISTERED_RESOURCE = -170,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_ID_OUT_OF_RANGE"]/*' />
        NVAPI_ID_OUT_OF_RANGE = -171,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_DISPLAYCONFIG_VALIDATION_FAILED"]/*' />
        NVAPI_DISPLAYCONFIG_VALIDATION_FAILED = -172,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_DPMST_CHANGED"]/*' />
        NVAPI_DPMST_CHANGED = -173,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INSUFFICIENT_BUFFER"]/*' />
        NVAPI_INSUFFICIENT_BUFFER = -174,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_ACCESS_DENIED"]/*' />
        NVAPI_ACCESS_DENIED = -175,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_MOSAIC_NOT_ACTIVE"]/*' />
        NVAPI_MOSAIC_NOT_ACTIVE = -176,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_SHARE_RESOURCE_RELOCATED"]/*' />
        NVAPI_SHARE_RESOURCE_RELOCATED = -177,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_REQUEST_USER_TO_DISABLE_DWM"]/*' />
        NVAPI_REQUEST_USER_TO_DISABLE_DWM = -178,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_D3D_DEVICE_LOST"]/*' />
        NVAPI_D3D_DEVICE_LOST = -179,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INVALID_CONFIGURATION"]/*' />
        NVAPI_INVALID_CONFIGURATION = -180,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_STEREO_HANDSHAKE_NOT_DONE"]/*' />
        NVAPI_STEREO_HANDSHAKE_NOT_DONE = -181,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_EXECUTABLE_PATH_IS_AMBIGUOUS"]/*' />
        NVAPI_EXECUTABLE_PATH_IS_AMBIGUOUS = -182,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_DEFAULT_STEREO_PROFILE_IS_NOT_DEFINED"]/*' />
        NVAPI_DEFAULT_STEREO_PROFILE_IS_NOT_DEFINED = -183,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_DEFAULT_STEREO_PROFILE_DOES_NOT_EXIST"]/*' />
        NVAPI_DEFAULT_STEREO_PROFILE_DOES_NOT_EXIST = -184,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_CLUSTER_ALREADY_EXISTS"]/*' />
        NVAPI_CLUSTER_ALREADY_EXISTS = -185,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_DPMST_DISPLAY_ID_EXPECTED"]/*' />
        NVAPI_DPMST_DISPLAY_ID_EXPECTED = -186,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INVALID_DISPLAY_ID"]/*' />
        NVAPI_INVALID_DISPLAY_ID = -187,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_STREAM_IS_OUT_OF_SYNC"]/*' />
        NVAPI_STREAM_IS_OUT_OF_SYNC = -188,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INCOMPATIBLE_AUDIO_DRIVER"]/*' />
        NVAPI_INCOMPATIBLE_AUDIO_DRIVER = -189,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_VALUE_ALREADY_SET"]/*' />
        NVAPI_VALUE_ALREADY_SET = -190,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_TIMEOUT"]/*' />
        NVAPI_TIMEOUT = -191,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_GPU_WORKSTATION_FEATURE_INCOMPLETE"]/*' />
        NVAPI_GPU_WORKSTATION_FEATURE_INCOMPLETE = -192,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_STEREO_INIT_ACTIVATION_NOT_DONE"]/*' />
        NVAPI_STEREO_INIT_ACTIVATION_NOT_DONE = -193,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_SYNC_NOT_ACTIVE"]/*' />
        NVAPI_SYNC_NOT_ACTIVE = -194,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_SYNC_MASTER_NOT_FOUND"]/*' />
        NVAPI_SYNC_MASTER_NOT_FOUND = -195,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INVALID_SYNC_TOPOLOGY"]/*' />
        NVAPI_INVALID_SYNC_TOPOLOGY = -196,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_ECID_SIGN_ALGO_UNSUPPORTED"]/*' />
        NVAPI_ECID_SIGN_ALGO_UNSUPPORTED = -197,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_ECID_KEY_VERIFICATION_FAILED"]/*' />
        NVAPI_ECID_KEY_VERIFICATION_FAILED = -198,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_FIRMWARE_OUT_OF_DATE"]/*' />
        NVAPI_FIRMWARE_OUT_OF_DATE = -199,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_FIRMWARE_REVISION_NOT_SUPPORTED"]/*' />
        NVAPI_FIRMWARE_REVISION_NOT_SUPPORTED = -200,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_LICENSE_CALLER_AUTHENTICATION_FAILED"]/*' />
        NVAPI_LICENSE_CALLER_AUTHENTICATION_FAILED = -201,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_D3D_DEVICE_NOT_REGISTERED"]/*' />
        NVAPI_D3D_DEVICE_NOT_REGISTERED = -202,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_RESOURCE_NOT_ACQUIRED"]/*' />
        NVAPI_RESOURCE_NOT_ACQUIRED = -203,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_TIMING_NOT_SUPPORTED"]/*' />
        NVAPI_TIMING_NOT_SUPPORTED = -204,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_HDCP_ENCRYPTION_FAILED"]/*' />
        NVAPI_HDCP_ENCRYPTION_FAILED = -205,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_PCLK_LIMITATION_FAILED"]/*' />
        NVAPI_PCLK_LIMITATION_FAILED = -206,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_NO_CONNECTOR_FOUND"]/*' />
        NVAPI_NO_CONNECTOR_FOUND = -207,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_HDCP_DISABLED"]/*' />
        NVAPI_HDCP_DISABLED = -208,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_API_IN_USE"]/*' />
        NVAPI_API_IN_USE = -209,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_NVIDIA_DISPLAY_NOT_FOUND"]/*' />
        NVAPI_NVIDIA_DISPLAY_NOT_FOUND = -210,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_PRIV_SEC_VIOLATION"]/*' />
        NVAPI_PRIV_SEC_VIOLATION = -211,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INCORRECT_VENDOR"]/*' />
        NVAPI_INCORRECT_VENDOR = -212,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_DISPLAY_IN_USE"]/*' />
        NVAPI_DISPLAY_IN_USE = -213,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_UNSUPPORTED_CONFIG_NON_HDCP_HMD"]/*' />
        NVAPI_UNSUPPORTED_CONFIG_NON_HDCP_HMD = -214,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_MAX_DISPLAY_LIMIT_REACHED"]/*' />
        NVAPI_MAX_DISPLAY_LIMIT_REACHED = -215,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INVALID_DIRECT_MODE_DISPLAY"]/*' />
        NVAPI_INVALID_DIRECT_MODE_DISPLAY = -216,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_GPU_IN_DEBUG_MODE"]/*' />
        NVAPI_GPU_IN_DEBUG_MODE = -217,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_D3D_CONTEXT_NOT_FOUND"]/*' />
        NVAPI_D3D_CONTEXT_NOT_FOUND = -218,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_STEREO_VERSION_MISMATCH"]/*' />
        NVAPI_STEREO_VERSION_MISMATCH = -219,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_GPU_NOT_POWERED"]/*' />
        NVAPI_GPU_NOT_POWERED = -220,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_ERROR_DRIVER_RELOAD_IN_PROGRESS"]/*' />
        NVAPI_ERROR_DRIVER_RELOAD_IN_PROGRESS = -221,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_WAIT_FOR_HW_RESOURCE"]/*' />
        NVAPI_WAIT_FOR_HW_RESOURCE = -222,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_REQUIRE_FURTHER_HDCP_ACTION"]/*' />
        NVAPI_REQUIRE_FURTHER_HDCP_ACTION = -223,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_DISPLAY_MUX_TRANSITION_FAILED"]/*' />
        NVAPI_DISPLAY_MUX_TRANSITION_FAILED = -224,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INVALID_DSC_VERSION"]/*' />
        NVAPI_INVALID_DSC_VERSION = -225,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INVALID_DSC_SLICECOUNT"]/*' />
        NVAPI_INVALID_DSC_SLICECOUNT = -226,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INVALID_DSC_OUTPUT_BPP"]/*' />
        NVAPI_INVALID_DSC_OUTPUT_BPP = -227,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_FAILED_TO_LOAD_FROM_DRIVER_STORE"]/*' />
        NVAPI_FAILED_TO_LOAD_FROM_DRIVER_STORE = -228,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_NO_VULKAN"]/*' />
        NVAPI_NO_VULKAN = -229,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_REQUEST_PENDING"]/*' />
        NVAPI_REQUEST_PENDING = -230,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_RESOURCE_IN_USE"]/*' />
        NVAPI_RESOURCE_IN_USE = -231,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INVALID_IMAGE"]/*' />
        NVAPI_INVALID_IMAGE = -232,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INVALID_PTX"]/*' />
        NVAPI_INVALID_PTX = -233,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_NVLINK_UNCORRECTABLE"]/*' />
        NVAPI_NVLINK_UNCORRECTABLE = -234,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_JIT_COMPILER_NOT_FOUND"]/*' />
        NVAPI_JIT_COMPILER_NOT_FOUND = -235,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INVALID_SOURCE"]/*' />
        NVAPI_INVALID_SOURCE = -236,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_ILLEGAL_INSTRUCTION"]/*' />
        NVAPI_ILLEGAL_INSTRUCTION = -237,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INVALID_PC"]/*' />
        NVAPI_INVALID_PC = -238,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_LAUNCH_FAILED"]/*' />
        NVAPI_LAUNCH_FAILED = -239,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_NOT_PERMITTED"]/*' />
        NVAPI_NOT_PERMITTED = -240,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_CALLBACK_ALREADY_REGISTERED"]/*' />
        NVAPI_CALLBACK_ALREADY_REGISTERED = -241,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_CALLBACK_NOT_FOUND"]/*' />
        NVAPI_CALLBACK_NOT_FOUND = -242,

        /// <include file='_NvAPI_Status.xml' path='doc/member[@name="_NvAPI_Status.NVAPI_INVALID_OUTPUT_WIRE_FORMAT"]/*' />
        NVAPI_INVALID_OUTPUT_WIRE_FORMAT = -243,
    }
}
