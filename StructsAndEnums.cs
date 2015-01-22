// Copyright © Microsoft, Inc.
//
// All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.


using System;

namespace ADALBinding
{
	public enum ADAuthenticationResultStatus {
		AD_SUCCEEDED,
		AD_USER_CANCELLED,
		AD_FAILED
	};

	public enum ADPromptBehavior {
		AD_PROMPT_AUTO,
		AD_PROMPT_ALWAYS,
		AD_PROMPT_REFRESH_SESSION
	};

	public enum ADAssertionType {
		AD_SAML1_1,
		AD_SAML2
	}

	public enum Idtype_t {
		P_ALL,
		P_PID,
		P_PGID
	};

	public enum SRefCon {
		NoErr = 0
	};

	public enum UnicodeScalarValue : uint {
		knownType = 1061109567
	}

	public enum Style : byte {
		Normal = 0,
		Bold = 1,
		Italic = 2,
		Underline = 4,
		Outline = 8,
		hadow = 16,
		Condense = 32,
		Extend = 64
	}

	public enum NumVersionVariant   {
		DevelopStage = 32,
		AlphaStage = 64,
		BetaStage = 96,
		FinalStage = 128
	}

	public enum Boolean_t {
		OSUnknownByteOrder,
		OSLittleEndian,
		OSBigEndian
	}

	public enum Filesec_property_t   {
		ILESEC_OWNER = 1,
		ILESEC_GROUP = 2,
		ILESEC_UUID = 3,
		ILESEC_MODE = 4,
		ILESEC_ACL = 5,
		ILESEC_GRPUUID = 6,
		ILESEC_ACL_RAW = 100,
		ILESEC_ACL_ALLOCSIZE = 101
	}

	public enum Acl_perm_t   {
		CL_READ_DATA = (1 << 1),
		CL_LIST_DIRECTORY = (1 << 1),
		CL_WRITE_DATA = (1 << 2),
		CL_ADD_FILE = (1 << 2),
		CL_EXECUTE = (1 << 3),
		CL_SEARCH = (1 << 3),
		CL_DELETE = (1 << 4),
		CL_APPEND_DATA = (1 << 5),
		CL_ADD_SUBDIRECTORY = (1 << 5),
		CL_DELETE_CHILD = (1 << 6),
		CL_READ_ATTRIBUTES = (1 << 7),
		CL_WRITE_ATTRIBUTES = (1 << 8),
		CL_READ_EXTATTRIBUTES = (1 << 9),
		CL_WRITE_EXTATTRIBUTES = (1 << 10),
		CL_READ_SECURITY = (1 << 11),
		CL_WRITE_SECURITY = (1 << 12),
		CL_CHANGE_OWNER = (1 << 13)
	}

	public enum Acl_tag_t   {
		CL_UNDEFINED_TAG = 0,
		CL_EXTENDED_ALLOW = 1,
		CL_EXTENDED_DENY = 2
	}

	public enum Acl_type_t   {
		CL_TYPE_EXTENDED = 256,
		CL_TYPE_ACCESS = 0,
		CL_TYPE_DEFAULT = 1,
		CL_TYPE_AFS = 2,
		CL_TYPE_CODA = 3,
		CL_TYPE_NTFS = 4,
		CL_TYPE_NWFS = 5
	}

	public enum Acl_entry_id_t   {
		CL_FIRST_ENTRY = 0,
		CL_NEXT_ENTRY = -1,
		CL_LAST_ENTRY = -2
	}

	public enum Acl_flag_t   {
		CL_FLAG_DEFER_INHERIT = (1 << 0),
		CL_FLAG_NO_INHERIT = (1 << 17),
		CL_ENTRY_INHERITED = (1 << 4),
		CL_ENTRY_FILE_INHERIT = (1 << 5),
		CL_ENTRY_DIRECTORY_INHERIT = (1 << 6),
		CL_ENTRY_LIMIT_INHERIT = (1 << 7),
		CL_ENTRY_ONLY_INHERIT = (1 << 8)
	}

	public enum ADAL_LOG_LEVEL   {
		ADAL_LOG_LEVEL_NO_LOG,
		ADAL_LOG_LEVEL_ERROR,
		ADAL_LOG_LEVEL_WARN,
		ADAL_LOG_LEVEL_INFO,
		ADAL_LOG_LEVEL_VERBOSE,
		ADAL_LOG_LAST = ADAL_LOG_LEVEL_VERBOSE
	}

	public enum ADErrorCode   {
		ERROR_SUCCEEDED = 0,
		ERROR_USER_CANCEL = 1,
		ERROR_INVALID_ARGUMENT = 2,
		ERROR_MISSING_AUTHENTICATE_HEADER = 3,
		ERROR_AUTHENTICATE_HEADER_BAD_FORMAT = 4,
		ERROR_CONNECTION_MISSING_RESPONSE = 5,
		ERROR_UNAUTHORIZED_CODE_EXPECTED = 6,
		ERROR_INVALID_REFRESH_TOKEN = 7,
		ERROR_UNEXPECTED = 8,
		ERROR_MULTIPLE_USERS = 9,
		ERROR_USER_INPUT_NEEDED = 10,
		ERROR_CACHE_PERSISTENCE = 11,
		ERROR_BAD_CACHE_FORMAT = 12,
		ERROR_USER_PROMPTED = 13,
		ERROR_APPLICATION = 14,
		ERROR_AUTHENTICATION = 15,
		ERROR_AUTHORITY_VALIDATION = 16,
		ERROR_NO_MAIN_VIEW_CONTROLLER = 17,
		ERROR_MISSING_RESOURCES = 18,
		ERROR_WRONG_USER = 19
	}

	public enum HTTPStatusCodes   {
		UNAUTHORIZED = 401
	}

	public enum ADCredentialsType{
		/*!
     The SDK determines automatically the most suitable option, optimized for user experience.
     E.g. it may invoke another application for a single sign on, if such application is present.
     This is the default option.
     */
		AD_CREDENTIALS_AUTO,

		/*!
     The SDK will present an embedded dialog within the application. It will not invoke external
     application or browser.
     */
		AD_CREDENTIALS_EMBEDDED,

	}
}
