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

namespace adalbinding
{
	// @protocol ADTokenCacheStoring
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	public partial interface ADTokenCacheStoring {

		// @required -(NSArray *)allItemsWithError:(ADAuthenticationError **)error;
		[Export ("allItemsWithError:")]
		NSObject [] AllItemsWithError (out ADAuthenticationError error);

		// @required -(ADTokenCacheStoreItem *)getItemWithKey:(ADTokenCacheStoreKey *)key userId:(NSString *)userId error:(ADAuthenticationError **)error;
		[Export ("getItemWithKey:userId:error:")]
		ADTokenCacheStoreItem GetItemWithKey (ADTokenCacheStoreKey key, string userId, out ADAuthenticationError error);

		// @required -(NSArray *)getItemsWithKey:(ADTokenCacheStoreKey *)key error:(ADAuthenticationError **)error;
		[Export ("getItemsWithKey:error:")]
		NSObject [] GetItemsWithKey (ADTokenCacheStoreKey key, out ADAuthenticationError error);

		// @required -(void)addOrUpdateItem:(ADTokenCacheStoreItem *)item error:(ADAuthenticationError **)error;
		[Export ("addOrUpdateItem:error:")]
		void AddOrUpdateItem (ADTokenCacheStoreItem item, out ADAuthenticationError error);

		// @required -(void)removeItemWithKey:(ADTokenCacheStoreKey *)key userId:(NSString *)userId error:(ADAuthenticationError **)error;
		[Export ("removeItemWithKey:userId:error:")]
		void RemoveItemWithKey (ADTokenCacheStoreKey key, string userId, out ADAuthenticationError error);

		// @required -(void)removeAllWithError:(ADAuthenticationError **)error;
		[Export ("removeAllWithError:")]
		void RemoveAllWithError (out ADAuthenticationError error);
	}

	public interface IADTokenCacheStoring {}

	// @interface ADAuthenticationError : NSError
	[BaseType (typeof (NSError))]
	public partial interface ADAuthenticationError {

		// @property (readonly) NSString * protocolCode;
		[Export ("protocolCode")]
		string ProtocolCode { get; }

		// @property (readonly) NSString * errorDetails;
		[Export ("errorDetails")]
		string ErrorDetails { get; }

		// +(ADAuthenticationError *)errorFromArgument:(id)argument argumentName:(NSString *)argumentName;
		[Static, Export ("errorFromArgument:argumentName:")]
		ADAuthenticationError ErrorFromArgument (NSObject argument, string argumentName);

		// +(ADAuthenticationError *)errorFromUnauthorizedResponse:(NSInteger)responseCode errorDetails:(NSString *)errorDetails;
		[Static, Export ("errorFromUnauthorizedResponse:errorDetails:")]
		ADAuthenticationError ErrorFromUnauthorizedResponse (int responseCode, string errorDetails);

		// +(ADAuthenticationError *)errorFromNSError:(NSError *)error errorDetails:(NSString *)errorDetails;
		[Static, Export ("errorFromNSError:errorDetails:")]
		ADAuthenticationError ErrorFromNSError (NSError error, string errorDetails);

		// +(ADAuthenticationError *)errorFromAuthenticationError:(NSInteger)code protocolCode:(NSString *)protocolCode errorDetails:(NSString *)errorDetails;
		[Static, Export ("errorFromAuthenticationError:protocolCode:errorDetails:")]
		ADAuthenticationError ErrorFromAuthenticationError (int code, string protocolCode, string errorDetails);

		// +(ADAuthenticationError *)unexpectedInternalError:(NSString *)errorDetails;
		[Static, Export ("unexpectedInternalError:")]
		ADAuthenticationError UnexpectedInternalError (string errorDetails);

		// +(ADAuthenticationError *)errorFromCancellation;
		[Static, Export ("errorFromCancellation")]
		ADAuthenticationError ErrorFromCancellation ();
	}

	// @interface ADAuthenticationResult : NSObject
	[BaseType (typeof (NSObject))]
	public partial interface ADAuthenticationResult {

		// @property (readonly) ADAuthenticationResultStatus status;
		[Export ("status")]
		ADAuthenticationResultStatus Status { get; }

		// @property (readonly) NSString * accessToken;
		[Export ("accessToken")]
		string AccessToken { get; }

		// @property (readonly) ADTokenCacheStoreItem * tokenCacheStoreItem;
		[Export ("tokenCacheStoreItem")]
		ADTokenCacheStoreItem TokenCacheStoreItem { get; }

		// @property (readonly) ADAuthenticationError * error;
		[Export ("error")]
		ADAuthenticationError Error { get; }

		// @property (readonly) BOOL multiResourceRefreshToken;
		[Export ("multiResourceRefreshToken")]
		bool MultiResourceRefreshToken { get; }
	}

	// @interface ADTokenCacheStoreItem : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof (NSObject))]
	public partial interface ADTokenCacheStoreItem{

		// @property NSString * resource;
		[Export ("resource")]
		string Resource { get; set; }

		// @property NSString * authority;
		[Export ("authority")]
		string Authority { get; set; }

		// @property NSString * clientId;
		[Export ("clientId")]
		string ClientId { get; set; }

		// @property NSString * accessToken;
		[Export ("accessToken")]
		string AccessToken { get; set; }

		// @property NSString * accessTokenType;
		[Export ("accessTokenType")]
		string AccessTokenType { get; set; }

		// @property NSString * refreshToken;
		[Export ("refreshToken")]
		string RefreshToken { get; set; }

		// @property NSDate * expiresOn;
		[Export ("expiresOn")]
		NSDate ExpiresOn { get; set; }

		// @property ADUserInformation * userInformation;
		[Export ("userInformation")]
		ADUserInformation UserInformation { get; set; }

		// @property (readonly, getter = isMultiResourceRefreshToken) BOOL multiResourceRefreshToken;
		[Export ("multiResourceRefreshToken")]
		bool MultiResourceRefreshToken { [Bind ("isMultiResourceRefreshToken")] get; }

		// -(ADTokenCacheStoreKey *)extractKeyWithError:(ADAuthenticationError **)error;
		[Export ("extractKeyWithError:")]
		ADTokenCacheStoreKey ExtractKeyWithError (out ADAuthenticationError error);

		// -(BOOL)isExpired;
		[Export ("isExpired")]
		bool IsExpired ();

		// -(BOOL)isEmptyUser;
		[Export ("isEmptyUser")]
		bool IsEmptyUser ();

		// -(BOOL)isSameUser:(ADTokenCacheStoreItem *)other;
		[Export ("isSameUser:")]
		bool IsSameUser (ADTokenCacheStoreItem other);
	}


	// @interface ADUserInformation : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof (NSObject))]
	public partial interface ADUserInformation {

		// @property (readonly) NSString * userId;
		[Export ("userId")]
		string UserId { get; }

		// @property (readonly) BOOL userIdDisplayable;
		[Export ("userIdDisplayable")]
		bool UserIdDisplayable { get; }

		// @property (readonly, getter = getGivenName) NSString * givenName;
		[Export ("givenName")]
		string GivenName { [Bind ("getGivenName")] get; }

		// @property (readonly, getter = getFamilyName) NSString * familyName;
		[Export ("familyName")]
		string FamilyName { [Bind ("getFamilyName")] get; }

		// @property (readonly, getter = getIdentityProvider) NSString * identityProvider;
		[Export ("identityProvider")]
		string IdentityProvider { [Bind ("getIdentityProvider")] get; }

		// @property (readonly, getter = getEMail) NSString * eMail;
		[Export ("eMail")]
		string EMail { [Bind ("getEMail")] get; }

		// @property (readonly, getter = getUniqueName) NSString * uniqueName;
		[Export ("uniqueName")]
		string UniqueName { [Bind ("getUniqueName")] get; }

		// @property (readonly, getter = getUpn) NSString * upn;
		[Export ("upn")]
		string Upn { [Bind ("getUpn")] get; }

		// @property (readonly, getter = getTenantId) NSString * tenantId;
		[Export ("tenantId")]
		string TenantId { [Bind ("getTenantId")] get; }

		// @property (readonly, getter = getSubject) NSString * subject;
		[Export ("subject")]
		string Subject { [Bind ("getSubject")] get; }

		// @property (readonly, getter = getUserObjectId) NSString * userObjectId;
		[Export ("userObjectId")]
		string UserObjectId { [Bind ("getUserObjectId")] get; }

		// @property (readonly, getter = getGuestId) NSString * guestId;
		[Export ("guestId")]
		string GuestId { [Bind ("getGuestId")] get; }

		// @property (readonly) NSString * rawIdToken;
		[Export ("rawIdToken")]
		string RawIdToken { get; }

		// @property (readonly) NSDictionary * allClaims;
		[Export ("allClaims")]
		NSDictionary AllClaims { get; }

		// +(ADUserInformation *)userInformationWithUserId:(NSString *)userId error:(ADAuthenticationError **)error;
		[Static, Export ("userInformationWithUserId:error:")]
		ADUserInformation UserInformationWithUserId (string userId, out ADAuthenticationError error);

		// +(ADUserInformation *)userInformationWithIdToken:(NSString *)idToken error:(ADAuthenticationError **)error;
		[Static, Export ("userInformationWithIdToken:error:")]
		ADUserInformation UserInformationWithIdToken (string idToken, out ADAuthenticationError error);

		// +(NSString *)normalizeUserId:(NSString *)userId;
		[Static, Export ("normalizeUserId:")]
		string NormalizeUserId (string userId);
	}

	// @interface ADTokenCacheStoreKey : NSObject <NSCopying>
	[BaseType (typeof (NSObject))]
	public partial interface ADTokenCacheStoreKey{

		// @property (readonly) NSString * authority;
		[Export ("authority")]
		string Authority { get; }

		// @property (readonly) NSString * resource;
		[Export ("resource")]
		string Resource { get; }

		// @property (readonly) NSString * clientId;
		[Export ("clientId")]
		string ClientId { get; }

		// +(ADTokenCacheStoreKey *)keyWithAuthority:(NSString *)authority resource:(NSString *)resource clientId:(NSString *)clientId error:(ADAuthenticationError **)error;
		[Static, Export ("keyWithAuthority:resource:clientId:error:")]
		ADTokenCacheStoreKey KeyWithAuthority (string authority, string resource, string clientId, out ADAuthenticationError error);
	}

	public delegate void ADAuthenticationCallback(ADAuthenticationResult result);

	// @interface ADAuthenticationContext : NSObject
	[BaseType (typeof (NSObject))]
	public partial interface ADAuthenticationContext {

		// -(id)initWithAuthority:(NSString *)authority validateAuthority:(BOOL)validateAuthority tokenCacheStore:(id<ADTokenCacheStoring>)tokenCache error:(ADAuthenticationError **)error;
		[Export ("initWithAuthority:validateAuthority:tokenCacheStore:error:")]
		IntPtr Constructor (string authority, bool validateAuthority, ADTokenCacheStoring tokenCache, out ADAuthenticationError error);

		// @property (readonly) NSString * authority;
		[Export ("authority")]
		string Authority { get; }

		// @property BOOL validateAuthority;
		[Export ("validateAuthority")]
		bool ValidateAuthority { get; set; }

		// @property id<ADTokenCacheStoring> tokenCacheStore;
		[Export ("tokenCacheStore")]
		IADTokenCacheStoring TokenCacheStore { get; set; }

		// @property (strong, getter = getCorrelationId, setter = setCorrelationId:) NSUUID * correlationId;
		[Export ("correlationId", ArgumentSemantic.Retain)]
		Guid CorrelationId { [Bind ("getCorrelationId")] get; set; }

		// @property (weak) UIViewController * parentController;
		[Export ("parentController", ArgumentSemantic.Weak)]
		UIViewController ParentController { get; set; }

		// @property (weak) UIWebView * webView;
		[Export ("webView", ArgumentSemantic.Weak)]
		UIWebView WebView { get; set; }

		// +(ADAuthenticationContext *)authenticationContextWithAuthority:(NSString *)authority error:(ADAuthenticationError **)error;
		[Static, Export ("authenticationContextWithAuthority:error:")]
		ADAuthenticationContext AuthenticationContextWithAuthority (string authority, out ADAuthenticationError error);

		// +(ADAuthenticationContext *)authenticationContextWithAuthority:(NSString *)authority validateAuthority:(BOOL)validate error:(ADAuthenticationError **)error;
		[Static, Export ("authenticationContextWithAuthority:validateAuthority:error:")]
		ADAuthenticationContext AuthenticationContextWithAuthority (string authority, bool validate, out ADAuthenticationError error);

		// +(ADAuthenticationContext *)authenticationContextWithAuthority:(NSString *)authority tokenCacheStore:(id<ADTokenCacheStoring>)tokenCache error:(ADAuthenticationError **)error;
		[Static, Export ("authenticationContextWithAuthority:tokenCacheStore:error:")]
		ADAuthenticationContext AuthenticationContextWithAuthority (string authority, ADTokenCacheStoring tokenCache, out ADAuthenticationError error);

		// +(ADAuthenticationContext *)authenticationContextWithAuthority:(NSString *)authority validateAuthority:(BOOL)validate tokenCacheStore:(id<ADTokenCacheStoring>)tokenCache error:(ADAuthenticationError **)error;
		[Static, Export ("authenticationContextWithAuthority:validateAuthority:tokenCacheStore:error:")]
		ADAuthenticationContext AuthenticationContextWithAuthority (string authority, bool validate, ADTokenCacheStoring tokenCache, out ADAuthenticationError error);

		// -(void)acquireTokenForAssertion:(NSString *)assertion assertionType:(ADAssertionType)assertionType resource:(NSString *)resource clientId:(NSString *)clientId userId:(NSString *)userId completionBlock:(ADAuthenticationCallback)completionBlock;
		[Export ("acquireTokenForAssertion:assertionType:resource:clientId:userId:completionBlock:")]
		void AcquireTokenForAssertion (string assertion, ADAssertionType assertionType, string resource, string clientId, string userId, Action<ADAuthenticationResult> completionBlock);

		// -(void)acquireTokenWithResource:(NSString *)resource clientId:(NSString *)clientId redirectUri:(NSURL *)redirectUri completionBlock:(ADAuthenticationCallback)completionBlock;
		[Export ("acquireTokenWithResource:clientId:redirectUri:completionBlock:")]
		void AcquireTokenWithResource (string resource, string clientId, NSUrl redirectUri, Action<ADAuthenticationResult> completionBlock);

		// -(void)acquireTokenWithResource:(NSString *)resource clientId:(NSString *)clientId redirectUri:(NSURL *)redirectUri userId:(NSString *)userId completionBlock:(ADAuthenticationCallback)completionBlock;
		[Export ("acquireTokenWithResource:clientId:redirectUri:userId:completionBlock:")]
		void AcquireTokenWithResource (string resource, string clientId, NSUrl redirectUri, string userId, Action<ADAuthenticationResult> completionBlock);

		// -(void)acquireTokenWithResource:(NSString *)resource clientId:(NSString *)clientId redirectUri:(NSURL *)redirectUri userId:(NSString *)userId extraQueryParameters:(NSString *)queryParams completionBlock:(ADAuthenticationCallback)completionBlock;
		[Export ("acquireTokenWithResource:clientId:redirectUri:userId:extraQueryParameters:completionBlock:")]
		void AcquireTokenWithResource (string resource, string clientId, NSUrl redirectUri, string userId, string queryParams, Action<ADAuthenticationResult> completionBlock);

		// -(void)acquireTokenWithResource:(NSString *)resource clientId:(NSString *)clientId redirectUri:(NSURL *)redirectUri promptBehavior:(ADPromptBehavior)promptBehavior userId:(NSString *)userId extraQueryParameters:(NSString *)queryParams completionBlock:(ADAuthenticationCallback)completionBlock;
		[Export ("acquireTokenWithResource:clientId:redirectUri:promptBehavior:userId:extraQueryParameters:completionBlock:")]
		void AcquireTokenWithResource (string resource, string clientId, NSUrl redirectUri, ADPromptBehavior promptBehavior, string userId, string queryParams, Action<ADAuthenticationResult> completionBlock);

		// -(void)acquireTokenSilentWithResource:(NSString *)resource clientId:(NSString *)clientId redirectUri:(NSURL *)redirectUri completionBlock:(ADAuthenticationCallback)completionBlock;
		[Export ("acquireTokenSilentWithResource:clientId:redirectUri:completionBlock:")]
		void AcquireTokenSilentWithResource (string resource, string clientId, NSUrl redirectUri, Action<ADAuthenticationResult> completionBlock);

		// -(void)acquireTokenSilentWithResource:(NSString *)resource clientId:(NSString *)clientId redirectUri:(NSURL *)redirectUri userId:(NSString *)userId completionBlock:(ADAuthenticationCallback)completionBlock;
		[Export ("acquireTokenSilentWithResource:clientId:redirectUri:userId:completionBlock:")]
		void AcquireTokenSilentWithResource (string resource, string clientId, NSUrl redirectUri, string userId, Action<ADAuthenticationResult> completionBlock);

		// -(void)acquireTokenByRefreshToken:(NSString *)refreshToken clientId:(NSString *)clientId completionBlock:(ADAuthenticationCallback)completionBlock;
		[Export ("acquireTokenByRefreshToken:clientId:completionBlock:")]
		void AcquireTokenByRefreshToken (string refreshToken, string clientId, Action<ADAuthenticationResult> completionBlock);

		// -(void)acquireTokenByRefreshToken:(NSString *)refreshToken clientId:(NSString *)clientId resource:(NSString *)resource completionBlock:(ADAuthenticationCallback)completionBlock;
		[Export ("acquireTokenByRefreshToken:clientId:resource:completionBlock:")]
		void AcquireTokenByRefreshToken (string refreshToken, string clientId, string resource, Action<ADAuthenticationResult> completionBlock);
	}


	public delegate void LogCallback(ADAL_LOG_LEVEL logLevel, string message, string additionalInformation, int errorCode);

	// @interface ADLogger : NSObject
	[BaseType (typeof (NSObject))]
	public partial interface ADLogger {

		// +(void)setLevel:(ADAL_LOG_LEVEL)logLevel;
		[Static, Export ("setLevel:")]
		void SetLevel ( ADAL_LOG_LEVEL level);

		// +(ADAL_LOG_LEVEL)getLevel;
		[Static, Export ("getLevel")]
		ADAL_LOG_LEVEL GetLevel ();

		// +(void)log:(ADAL_LOG_LEVEL)logLevel message:(NSString *)message errorCode:(NSInteger)errorCode additionalInformation:(NSString *)additionalInformation;
		[Static, Export ("log:message:errorCode:additionalInformation:")]
		void Log (ADAL_LOG_LEVEL logLevel, string message, int errorCode, string additionalInformation);

		// +(void)logToken:(NSString *)token tokenType:(NSString *)tokenType expiresOn:(NSDate *)expiresOn correlationId:(NSUUID *)correlationId;
		[Static, Export ("logToken:tokenType:expiresOn:correlationId:")]
		void LogToken (string token, string tokenType, NSDate expiresOn, Guid correlationId);

		// +(void)setLogCallBack:(LogCallback)callback;
		[Static, Export ("setLogCallBack:")]
		void SetLogCallBack (LogCallback callback);

		// +(LogCallback)getLogCallBack;
		[Static, Export ("getLogCallBack")]
		LogCallback GetLogCallBack ();

		// +(void)setNSLogging:(BOOL)nslogging;
		[Static, Export ("setNSLogging:")]
		void SetNSLogging (bool nslogging);

		// +(BOOL)getNSLogging;
		[Static, Export ("getNSLogging")]
		bool GetNSLogging ();

		// +(NSDictionary *)adalId;
		[Static, Export ("adalId")]
		NSDictionary AdalId ();

		// +(NSString *)getHash:(NSString *)input;
		[Static, Export ("getHash:")]
		string GetHash (string input);

		// +(void)setCorrelationId:(NSUUID *)correlationId;
		[Static, Export ("setCorrelationId:")]
		void SetCorrelationId (Guid correlationId);

		// +(NSUUID *)getCorrelationId;
		[Static, Export ("getCorrelationId")]
		Guid GetCorrelationId ();

		// +(NSString *)getAdalVersion;
		[Static, Export ("getAdalVersion")]
		string GetAdalVersion ();
	}

	public delegate void ADDiscoveryCallback(bool validated, ADAuthenticationError error);

	// @interface ADInstanceDiscovery : NSObject
	[BaseType (typeof (NSObject))]
	public partial interface ADInstanceDiscovery {

		// @property (readonly, getter = getValidatedAuthorities) NSSet * validatedAuthorities;
		[Export ("validatedAuthorities")]
		NSSet ValidatedAuthorities { [Bind ("getValidatedAuthorities")] get; }

		// +(ADInstanceDiscovery *)sharedInstance;
		[Static, Export ("sharedInstance")]
		ADInstanceDiscovery SharedInstance ();

		// -(void)validateAuthority:(NSString *)authority correlationId:(NSUUID *)correlationId completionBlock:(ADDiscoveryCallback)completionBlock;
		[Export ("validateAuthority:correlationId:completionBlock:")]
		void ValidateAuthority (string authority, Guid correlationId, ADDiscoveryCallback completionBlock);

		// +(NSString *)canonicalizeAuthority:(NSString *)authority;
		[Static, Export ("canonicalizeAuthority:")]
		string CanonicalizeAuthority (string authority);
	}

	[Protocol]
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

	// @interface ADAuthenticationSettings : NSObject
	[BaseType (typeof (NSObject))]
	public partial interface ADAuthenticationSettings {

		// @property ADCredentialsType credentialsType;
		[Export ("credentialsType")]
		ADCredentialsType CredentialsType { get; set; }

		// @property int requestTimeOut;
		[Export ("requestTimeOut")]
		int RequestTimeOut { get; set; }

		// @property uint expirationBuffer;
		[Export ("expirationBuffer")]
		uint ExpirationBuffer { get; set; }

		// @property BOOL enableFullScreen;
		[Export ("enableFullScreen")]
		bool EnableFullScreen { get; set; }

		// @property dispatch_queue_t dispatchQueue;
		[Export ("dispatchQueue")]
		NSObject DispatchQueue { get; set; }

		// @property id<ADTokenCacheStoring> defaultTokenCacheStore;
		[Export ("defaultTokenCacheStore")]
		IADTokenCacheStoring DefaultTokenCacheStore { get; set; }

		// @property (getter = getSharedCacheKeychainGroup, setter = setSharedCacheKeychainGroup:) NSString * sharedCacheKeychainGroup;
		[Export ("sharedCacheKeychainGroup")]
		string SharedCacheKeychainGroup { [Bind ("getSharedCacheKeychainGroup")] get; set; }

		// @property NSString * clientTLSKeychainGroup;
		[Export ("clientTLSKeychainGroup")]
		string ClientTLSKeychainGroup { get; set; }

		// +(ADAuthenticationSettings *)sharedInstance;
		[Static, Export ("sharedInstance")]
		ADAuthenticationSettings SharedInstance ();
	}

	public delegate void ADParametersCompletion(ADAuthenticationParameters parameters, ADAuthenticationError error);

	// @interface ADAuthenticationParameters : NSObject
	[BaseType (typeof (NSObject))]
	public partial interface ADAuthenticationParameters {

		// @property (readonly) NSString * authority;
		[Export ("authority")]
		string Authority { get; }

		// @property (readonly) NSString * resource;
		[Export ("resource")]
		string Resource { get; }

		// @property (readonly, getter = getExtractedParameters) NSDictionary * extractedParameters;
		[Export ("extractedParameters")]
		NSDictionary ExtractedParameters { [Bind ("getExtractedParameters")] get; }

		// +(ADAuthenticationParameters *)parametersFromResponse:(NSHTTPURLResponse *)response error:(ADAuthenticationError **)error;
		[Static, Export ("parametersFromResponse:error:")]
		ADAuthenticationParameters ParametersFromResponse (NSUrlResponse response, out ADAuthenticationError error);

		// +(ADAuthenticationParameters *)parametersFromResponseAuthenticateHeader:(NSString *)authenticateHeader error:(ADAuthenticationError **)error;
		[Static, Export ("parametersFromResponseAuthenticateHeader:error:")]
		ADAuthenticationParameters ParametersFromResponseAuthenticateHeader (string authenticateHeader, out ADAuthenticationError error);

		// +(void)parametersFromResourceUrl:(NSURL *)resourceUrl completionBlock:(ADParametersCompletion)completion;
		[Static, Export ("parametersFromResourceUrl:completionBlock:")]
		void ParametersFromResourceUrl (NSUrl resourceUrl, ADParametersCompletion completion);
	}
}
