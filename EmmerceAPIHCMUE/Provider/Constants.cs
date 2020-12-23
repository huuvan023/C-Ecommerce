using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmmerceAPIHCMUE.Provider
{
    public class Constants
    {
        private static Constants instance;
        public static Constants Instance
        {
            get
            {
                if (instance == null) instance = new Constants();
                return Constants.instance;
            }
        }
        private Constants() { }
        // Bấm CTR + R + E để đóng gói
        private int sUCCESS_CODE = 1;
        private int fAIL_CODE = 0;
        private string bAD_REQUEST = "BAD_REQUEST!";
        private string sESSION_EXPIRED = "SESSION_EXPIRED";
        private string uSER_NOT_AUTHENTICATED = "USER_NOT_AUTHENTICATED!";
        private string sOMETHING_WAS_WRONG = "SOMETHING_WAS_WRONG!";
        private string nO_DATA = "NO_DATA";
        private string LOGIN_SUCCESS = "LOGIN_SUCCESS";
        private string LOGIN_FAIL = "LOGIN_FAIL";
        private string SUCCESS_MESSAGE = "SUCCESS!";
        private string FAIL_MESSAGE = "FAIL_MESSAGE";
        private string mySecret = "asdv234234^&%&^%&^hjsdfb2%%%";
        private string myIssuer = "huuvan";
        private string myAudience = "CNTTD";
        private string EMAIL_NOT_EXIST = "EMAIL_NOT_EXIST";
        public int SUCCESS_CODE { get => sUCCESS_CODE; }
        public int FAIL_CODE { get => fAIL_CODE;  }
        public string BAD_REQUEST { get => bAD_REQUEST; }
        public string SESSION_EXPIRED { get => sESSION_EXPIRED;  }
        public string USER_NOT_AUTHENTICATED { get => uSER_NOT_AUTHENTICATED; }
        public string SOMETHING_WAS_WRONG { get => sOMETHING_WAS_WRONG; }
        public string NO_DATA { get => nO_DATA;}
        public string LOGIN_FAIL1 { get => LOGIN_FAIL; set => LOGIN_FAIL = value; }
        public string LOGIN_SUCCESS1 { get => LOGIN_SUCCESS; set => LOGIN_SUCCESS = value; }
        public string SUCCESS_MESSAGE1 { get => SUCCESS_MESSAGE; set => SUCCESS_MESSAGE = value; }
        public string FAIL_MESSAGE1 { get => FAIL_MESSAGE; set => FAIL_MESSAGE = value; }
        public string MySecret { get => mySecret; }
        public string MyIssuer { get => myIssuer;}
        public string MyAudience { get => myAudience; }
        public string EMAIL_NOT_EXIST1 { get => EMAIL_NOT_EXIST; }
    }
}
