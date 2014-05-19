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
using System.Drawing;
using System.Net;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Binding
{
	[Model]
	public partial interface ADTokenCacheStoring {

		[Export ("allItems")]
		NSObject [] AllItems { get; }

		[Export ("getItemWithKey:userId:")]
		ADTokenCacheStoreItem GetItemWithKey (ADTokenCacheStoreKey key, string userId);

		[Export ("getItemsWithKey:")]
		NSObject [] GetItemsWithKey (ADTokenCacheStoreKey key);

		[Export ("addOrUpdateItem:error:")]
		void AddOrUpdateItem (ADTokenCacheStoreItem item, out ADAuthenticationError error);

		[Export ("removeItemWithKey:userId:")]
		void RemoveItemWithKey (ADTokenCacheStoreKey key, string userId);

		[Export ("removeAll")]
		void RemoveAll ();

		[Field ("ADAuthenticationErrorDomain")]
		NSString ADAuthenticationErrorDomain { get; }

		[Field ("ADInvalidArgumentDomain")]
		NSString ADInvalidArgumentDomain { get; }

		[Field ("ADUnauthorizedResponseErrorDomain")]
		NSString ADUnauthorizedResponseErrorDomain { get; }
	}

	[BaseType (typeof (NSError))]
	public partial interface ADAuthenticationError {

		[Export ("protocolCode")]
		string ProtocolCode { get; }

		[Export ("errorDetails")]
		string ErrorDetails { get; }

		[Static, Export ("errorFromArgument:argumentName:")]
		ADAuthenticationError ErrorFromArgument (NSObject argument, string argumentName);

		[Static, Export ("errorFromUnauthorizedResponse:errorDetails:")]
		ADAuthenticationError ErrorFromUnauthorizedResponse (int responseCode, string errorDetails);

		[Static, Export ("errorFromNSError:errorDetails:")]
		ADAuthenticationError ErrorFromNSError (NSError error, string errorDetails);

		[Static, Export ("errorFromAuthenticationError:protocolCode:errorDetails:")]
		ADAuthenticationError ErrorFromAuthenticationError (int code, string protocolCode, string errorDetails);

		[Static, Export ("unexpectedInternalError:")]
		ADAuthenticationError UnexpectedInternalError (string errorDetails);

		[Static, Export ("errorFromCancellation")]
		ADAuthenticationError ErrorFromCancellation { get; }
	}

	[BaseType (typeof (NSObject))]
	public partial interface ADAuthenticationResult {

		[Export ("status")]
		ADAuthenticationResultStatus Status { get; }

		[Export ("accessToken")]
		string AccessToken { get; }

		[Export ("tokenCacheStoreItem")]
		ADTokenCacheStoreItem TokenCacheStoreItem { get; }

		[Export ("error")]
		ADAuthenticationError Error { get; }

		[Export ("multiResourceRefreshToken")]
		bool MultiResourceRefreshToken { get; }
	}

	[BaseType (typeof (NSObject))]
	public partial interface ADTokenCacheStoreItem {

		[Export ("resource")]
		string Resource { get; set; }

		[Export ("authority")]
		string Authority { get; set; }

		[Export ("clientId")]
		string ClientId { get; set; }

		[Export ("accessToken")]
		string AccessToken { get; set; }

		[Export ("accessTokenType")]
		string AccessTokenType { get; set; }

		[Export ("refreshToken")]
		string RefreshToken { get; set; }

		[Export ("expiresOn")]
		NSDate ExpiresOn { get; set; }

		[Export ("userInformation")]
		ADUserInformation UserInformation { get; set; }

		[Export ("multiResourceRefreshToken")]
		bool MultiResourceRefreshToken { [Bind ("isMultiResourceRefreshToken")] get; }

		[Export ("extractKeyWithError:")]
		ADTokenCacheStoreKey ExtractKeyWithError (out ADAuthenticationError error);

		[Export ("isExpired")]
		bool IsExpired { get; }

		[Export ("isEmptyUser")]
		bool IsEmptyUser { get; }

		[Export ("isSameUser:")]
		bool IsSameUser (ADTokenCacheStoreItem other);
	}

	[BaseType (typeof (NSObject))]
	public partial interface ADUserInformation {

		[Static, Export ("userInformationWithUserId:error:")]
		ADUserInformation UserInformationWithUserId (string userId, out ADAuthenticationError error);

		[Static, Export ("userInformationWithIdToken:error:")]
		ADUserInformation UserInformationWithIdToken (string idToken, out ADAuthenticationError error);

		[Export ("userId")]
		string UserId { get; }

		[Export ("userIdDisplayable")]
		bool UserIdDisplayable { get; set; }

		[Export ("givenName")]
		string GivenName { get; set; }

		[Export ("familyName")]
		string FamilyName { get; set; }

		[Export ("identityProvider")]
		string IdentityProvider { get; set; }

		[Export ("eMail")]
		string EMail { get; set; }

		[Export ("uniqueName")]
		string UniqueName { get; set; }

		[Export ("upn")]
		string Upn { get; set; }

		[Export ("tenantId")]
		string TenantId { get; set; }

		[Export ("subject")]
		string Subject { get; set; }

		[Export ("userObjectId")]
		string UserObjectId { get; set; }

		[Export ("guestId")]
		string GuestId { get; set; }

		[Static, Export ("normalizeUserId:")]
		string NormalizeUserId (string userId);
	}

	[BaseType (typeof (NSObject))]
	public partial interface ADTokenCacheStoreKey {

		[Static, Export ("keyWithAuthority:resource:clientId:error:")]
		ADTokenCacheStoreKey KeyWithAuthority (string authority, string resource, string clientId, out ADAuthenticationError error);

		[Export ("authority")]
		string Authority { get; }

		[Export ("resource")]
		string Resource { get; }

		[Export ("clientId")]
		string ClientId { get; }
	}

	public delegate void ADAuthenticationCallback(ADAuthenticationResult result);

	[BaseType (typeof (NSObject))]
	public partial interface ADAuthenticationContext {

		[Export ("initWithAuthority:validateAuthority:tokenCacheStore:error:")]
		IntPtr Constructor (string authority, bool validateAuthority, ADTokenCacheStoring tokenCache, out ADAuthenticationError error);

		[Static, Export ("authenticationContextWithAuthority:error:")]
		ADAuthenticationContext AuthenticationContextWithAuthority (string authority, out ADAuthenticationError error);

		[Static, Export ("authenticationContextWithAuthority:validateAuthority:error:")]
		ADAuthenticationContext AuthenticationContextWithAuthority (string authority, bool validate, out ADAuthenticationError error);

		[Static, Export ("authenticationContextWithAuthority:tokenCacheStore:error:")]
		ADAuthenticationContext AuthenticationContextWithAuthority (string authority, ADTokenCacheStoring tokenCache, out ADAuthenticationError error);

		[Static, Export ("authenticationContextWithAuthority:validateAuthority:tokenCacheStore:error:")]
		ADAuthenticationContext AuthenticationContextWithAuthority (string authority, bool validate, ADTokenCacheStoring tokenCache, out ADAuthenticationError error);

		[Export ("authority")]
		string Authority { get; }

		[Export ("validateAuthority")]
		bool ValidateAuthority { get; set; }

		[Export ("tokenCacheStore")]
		ADTokenCacheStoring TokenCacheStore { get; set; }

		[Export ("correlationId")]
		Guid CorrelationId { get; set; }

		[Export ("parentController")]
		UIViewController ParentController { get; set; }

		[Export ("acquireTokenWithResource:clientId:redirectUri:completionBlock:")]
		void AcquireTokenWithResource (string resource, string clientId, NSUrl redirectUri, ADAuthenticationCallback completionBlock);

		[Export ("acquireTokenWithResource:clientId:redirectUri:userId:completionBlock:")]
		void AcquireTokenWithResource (string resource, string clientId, NSUrl redirectUri, string userId, ADAuthenticationCallback completionBlock);

		[Export ("acquireTokenWithResource:clientId:redirectUri:userId:extraQueryParameters:completionBlock:")]
		void AcquireTokenWithResource (string resource, string clientId, NSUrl redirectUri, string userId, string queryParams, ADAuthenticationCallback completionBlock);

		[Export ("acquireTokenWithResource:clientId:redirectUri:promptBehavior:userId:extraQueryParameters:completionBlock:")]
		void AcquireTokenWithResource (string resource, string clientId, NSUrl redirectUri, ADPromptBehavior promptBehavior, string userId, string queryParams, ADAuthenticationCallback completionBlock);

		[Export ("acquireTokenByRefreshToken:clientId:completionBlock:")]
		void AcquireTokenByRefreshToken (string refreshToken, string clientId, ADAuthenticationCallback completionBlock);

		[Export ("acquireTokenByRefreshToken:clientId:resource:completionBlock:")]
		void AcquireTokenByRefreshToken (string refreshToken, string clientId, string resource, ADAuthenticationCallback completionBlock);
	}

	public delegate void LogCallback(ADAL_LOG_LEVEL logLevel, string message, string additionalInformation, int errorCode);

	[BaseType (typeof (NSObject))]
	public partial interface ADLogger {

		[Static, Export ("level")]
		ADAL_LOG_LEVEL Level { set; }

		[Static, Export ("getLevel")]
		ADAL_LOG_LEVEL GetLevel { get; }

		[Static, Export ("log:message:errorCode:additionalInformation:")]
		void Log (ADAL_LOG_LEVEL logLevel, string message, int errorCode, string additionalInformation);

		[Static, Export ("logToken:tokenType:expiresOn:correlationId:")]
		void LogToken (string token, string tokenType, NSDate expiresOn, Guid correlationId);

		[Static, Export ("logCallBack")]
		LogCallback LogCallBack { set; }

		[Static, Export ("getLogCallBack")]
		LogCallback GetLogCallBack { get; }

		[Static, Export ("nSLogging")]
		bool NSLogging { set; }

		[Static, Export ("getNSLogging")]
		bool GetNSLogging { get; }

		[Static, Export ("adalId")]
		NSDictionary AdalId { get; }
	}
		
	public delegate void ADDiscoveryCallback(bool validated, ADAuthenticationError error);

	[BaseType (typeof (NSObject))]
	public partial interface ADInstanceDiscovery {

		[Export ("validatedAuthorities")]
		NSSet ValidatedAuthorities { [Bind ("getValidatedAuthorities")] get; }

		[Static, Export ("sharedInstance")]
		ADInstanceDiscovery SharedInstance { get; }

		[Export ("validateAuthority:correlationId:completionBlock:")]
		void ValidateAuthority (string authority, Guid correlationId, ADDiscoveryCallback completionBlock);

		[Static, Export ("canonicalizeAuthority:")]
		string CanonicalizeAuthority (string authority);

	}

	[BaseType (typeof (NSObject))]
	public partial interface ADPersistentTokenCacheStore : ADTokenCacheStoring {

		[Export ("initWithLocation:")]
		IntPtr Constructor (string cacheLocation);

		[Export ("removeItem:error:")]
		void RemoveItem (ADTokenCacheStoreItem item, out ADAuthenticationError error);

		[Export ("cacheLocation")]
		string CacheLocation { get; }

		[Export ("ensureArchived:")]
		bool EnsureArchived (out ADAuthenticationError error);

		[Export ("addInitialCacheItems")]
		bool AddInitialCacheItems { get; }

	}

	[BaseType (typeof (NSObject))]
	public partial interface ADAuthenticationSettings {

		[Static, Export ("sharedInstance")]
		ADAuthenticationSettings SharedInstance { get; }

		[Export ("credentialsType")]
		ADCredentialsType CredentialsType { get; set; }

		[Export ("requestTimeOut")]
		int RequestTimeOut { get; set; }

		[Export ("expirationBuffer")]
		uint ExpirationBuffer { get; set; }

		[Export ("enableFullScreen")]
		bool EnableFullScreen { get; set; }

		[Export ("dispatchQueue")]
		NSObject DispatchQueue { get; set; }

		[Export ("defaultTokenCacheStore")]
		ADTokenCacheStoring DefaultTokenCacheStore { get; set; }
    }

	public delegate void ADParametersCompletion(ADAuthenticationParameters parameters, ADAuthenticationError error);

	[BaseType (typeof (NSObject))]
	public partial interface ADAuthenticationParameters {

		[Export ("authority")]
		string Authority { get; }

		[Export ("resource")]
		string Resource { get; }

		[Export ("extractedParameters")]
		NSDictionary ExtractedParameters { [Bind ("getExtractedParameters")] get; }

		[Static, Export ("parametersFromResponse:error:")]
		ADAuthenticationParameters ParametersFromResponse (NSUrlResponse response, out ADAuthenticationError error);

		[Static, Export ("parametersFromResponseAuthenticateHeader:error:")]
		ADAuthenticationParameters ParametersFromResponseAuthenticateHeader (string authenticateHeader, out ADAuthenticationError error);

		[Static, Export ("parametersFromResourceUrl:completionBlock:")]
		void ParametersFromResourceUrl (NSUrl resourceUrl, ADParametersCompletion completion);
	}
}
