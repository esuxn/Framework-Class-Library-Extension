﻿using System;


namespace Whathecode.Interop
{
	public partial class AdvApi32
	{
		#region Access tokens.

		/// <summary>
		///   The <see cref="TokenElevationType"/> enumeration indicates the elevation type of token being queried by the GetTokenInformation function.
		/// </summary>
		public enum TokenElevationType
		{
			/// <summary>
			///   The token does not have a linked token.
			/// </summary>
			TokenElevationTypeDefault = 1,
			/// <summary>
			///   The token is an elevated token.
			/// </summary>
			TokenElevationTypeFull,
			/// <summary>
			///   The token is a limited token.
			/// </summary>
			TokenElevationTypeLimited
		}


		/// <summary>
		///   The <see cref="TokenInformationClass"/> enumeration contains values that specify the type of information being assigned to or retrieved from an access token.
		///   The GetTokenInformation function uses these values to indicate the type of token information to retrieve.
		///   The SetTokenInformation function uses these values to set the token information.
		/// </summary>
		public enum TokenInformationClass
		{
			/// <summary>
			///   The buffer receives a TOKEN_USER structure that contains the user account of the token.
			/// </summary>
			TokenUser = 1,
			/// <summary>
			///   The buffer receives a TOKEN_GROUPS structure that contains the group accounts associated with the token.
			/// </summary>
			TokenGroups,
			/// <summary>
			///   The buffer receives a TOKEN_PRIVILEGES structure that contains the privileges of the token.
			/// </summary>
			TokenPrivileges,
			/// <summary>
			///   The buffer receives a TOKEN_OWNER structure that contains the default owner security identifier (SID) for newly created objects.
			/// </summary>
			TokenOwner,
			/// <summary>
			///   The buffer receives a TOKEN_PRIMARY_GROUP structure that contains the default primary group SID for newly created objects.
			/// </summary>
			TokenPrimaryGroup,
			/// <summary>
			///   The buffer receives a TOKEN_DEFAULT_DACL structure that contains the default DACL for newly created objects.
			/// </summary>
			TokenDefaultDacl,
			/// <summary>
			///   The buffer receives a TOKEN_SOURCE structure that contains the source of the token. TOKEN_QUERY_SOURCE access is needed to retrieve this information.
			/// </summary>
			TokenSource,
			/// <summary>
			///   The buffer receives a TOKEN_TYPE value that indicates whether the token is a primary or impersonation token.
			/// </summary>
			TokenType,
			/// <summary>
			///   The buffer receives a SECURITY_IMPERSONATION_LEVEL value that indicates the impersonation level of the token. If the access token is not an impersonation token, the function fails.
			/// </summary>
			TokenImpersonationLevel,
			/// <summary>
			///   The buffer receives a TOKEN_STATISTICS structure that contains various token statistics.
			/// </summary>
			TokenStatistics,
			/// <summary>
			///   The buffer receives a TOKEN_GROUPS structure that contains the list of restricting SIDs in a restricted token.
			/// </summary>
			TokenRestrictedSids,
			/// <summary>
			///   The buffer receives a DWORD value that indicates the Terminal Services session identifier that is associated with the token.
			///   If the token is associated with the terminal server client session, the session identifier is nonzero.
			///   Windows Server 2003 and Windows XP: If the token is associated with the terminal server console session, the session identifier is zero.
			///   In a non-Terminal Services environment, the session identifier is zero.
			///   If TokenSessionId is set with SetTokenInformation,
			///   the application must have the Act As Part Of the Operating System privilege, and the application must be enabled to set the session ID in a token.
			/// </summary>
			TokenSessionId,
			/// <summary>
			///   The buffer receives a TOKEN_GROUPS_AND_PRIVILEGES structure that contains the user SID, the group accounts, the restricted SIDs, and the authentication ID associated with the token.
			/// </summary>
			TokenGroupsAndPrivileges,
			/// <summary>
			///   Reserved.
			/// </summary>
			TokenSessionReference,
			/// <summary>
			///   The buffer receives a DWORD value that is nonzero if the token includes the SANDBOX_INERT flag.
			/// </summary>
			TokenSandBoxInert,
			/// <summary>
			///   Reserved.
			/// </summary>
			TokenAuditPolicy,
			/// <summary>
			///   The buffer receives a TOKEN_ORIGIN value.
			///   If the token resulted from a logon that used explicit credentials,
			///   such as passing a name, domain, and password to the LogonUser function, then the TOKEN_ORIGIN structure will contain the ID of the logon session that created it.
			///   If the token resulted from network authentication,
			///   such as a call to AcceptSecurityContext or a call to LogonUser with dwLogonType set to LOGON32_LOGON_NETWORK or LOGON32_LOGON_NETWORK_CLEARTEXT, then this value will be zero.
			/// </summary>
			TokenOrigin,
			/// <summary>
			///   The buffer receives a TOKEN_ELEVATION_TYPE value that specifies the elevation level of the token.
			/// </summary>
			TokenElevationType,
			/// <summary>
			///   The buffer receives a TOKEN_LINKED_TOKEN structure that contains a handle to another token that is linked to this token.
			/// </summary>
			TokenLinkedToken,
			/// <summary>
			///   The buffer receives a TOKEN_ELEVATION structure that specifies whether the token is elevated.
			/// </summary>
			TokenElevation,
			/// <summary>
			///   The buffer receives a DWORD value that is nonzero if the token has ever been filtered.
			/// </summary>
			TokenHasRestrictions,
			/// <summary>
			///   The buffer receives a TOKEN_ACCESS_INFORMATION structure that specifies security information contained in the token.
			/// </summary>
			TokenAccessInformation,
			/// <summary>
			///   The buffer receives a DWORD value that is nonzero if virtualization is allowed for the token.
			/// </summary>
			TokenVirtualizationAllowed,
			/// <summary>
			///   The buffer receives a DWORD value that is nonzero if virtualization is enabled for the token.
			/// </summary>
			TokenVirtualizationEnabled,
			/// <summary>
			///   The buffer receives a TOKEN_MANDATORY_LABEL structure that specifies the token's integrity level. 
			/// </summary>
			TokenIntegrityLevel,
			/// <summary>
			///   The buffer receives a DWORD value that is nonzero if the token has the UIAccess flag set.
			/// </summary>
			TokenUIAccess,
			/// <summary>
			///   The buffer receives a TOKEN_MANDATORY_POLICY structure that specifies the token's mandatory integrity policy.
			/// </summary>
			TokenMandatoryPolicy,
			/// <summary>
			///   The buffer receives the token's logon security identifier (SID).
			/// </summary>
			TokenLogonSid,
			/// <summary>
			///   The buffer receives a DWORD value that is nonzero if the token is an app container token.
			///   Any callers who check the TokenIsAppContainer and have it return 0 should also verify that the caller token is not an identify level impersonation token.
			///   If the current token is not an app container but is an identity level token, you should return AccessDenied.
			/// </summary>
			TokenIsAppContainer,
			/// <summary>
			///   The buffer receives a TOKEN_GROUPS structure that contains the capabilities associated with the token.
			/// </summary>
			TokenCapabilities,
			/// <summary>
			///   The buffer receives a TOKEN_APPCONTAINER_INFORMATION structure that contains the AppContainerSid associated with the token.
			///   If the token is not associated with an app container, the TokenAppContainer member of the TOKEN_APPCONTAINER_INFORMATION structure points to NULL.
			/// </summary>
			TokenAppContainerSid,
			/// <summary>
			///   The buffer receives a DWORD value that includes the app container number for the token. For tokens that are not app container tokens, this value is zero.
			/// </summary>
			TokenAppContainerNumber,
			/// <summary>
			///   The buffer receives a CLAIM_SECURITY_ATTRIBUTES_INFORMATION structure that contains the user claims associated with the token.
			/// </summary>
			TokenUserClaimAttributes,
			/// <summary>
			///   The buffer receives a CLAIM_SECURITY_ATTRIBUTES_INFORMATION structure that contains the device claims associated with the token.
			/// </summary>
			TokenDeviceClaimAttributes,
			/// <summary>
			///   This value is reserved.
			/// </summary>
			TokenRestrictedUserClaimAttributes,
			/// <summary>
			///   This value is reserved.
			/// </summary>
			TokenRestrictedDeviceClaimAttributes,
			/// <summary>
			///   The buffer receives a TOKEN_GROUPS structure that contains the device groups that are associated with the token.
			/// </summary>
			TokenDeviceGroups,
			/// <summary>
			///   The buffer receives a TOKEN_GROUPS structure that contains the restricted device groups that are associated with the token.
			/// </summary>
			TokenRestrictedDeviceGroups,
			/// <summary>
			///   This value is reserved.
			/// </summary>
			TokenSecurityAttributes,
			/// <summary>
			///   This value is reserved.
			/// </summary>
			TokenIsRestricted,
			/// <summary>
			///   The maximum value for this enumeration
			/// </summary>
			MaxTokenInfoClass
		}

		/// <summary>
		///   The <see cref = "SecurityImpersonationLevel" /> enumeration contains values that specify security impersonation levels.
		///   Security impersonation levels govern the degree to which a server process can act on behalf of a client process.
		/// </summary>
		public enum SecurityImpersonationLevel
		{
			/// <summary>
			///   The server process cannot obtain identification information about the client, and it cannot impersonate the client.
			///   It is defined with no value given, and thus, by ANSI C rules, defaults to a value of zero.
			/// </summary>
			SecurityAnonymous,
			/// <summary>
			///   The server process can obtain information about the client, such as security identifiers and privileges, but it cannot impersonate the client.
			///   This is useful for servers that export their own objects, for example, database products that export tables and views.
			///   Using the retrieved client-security information, the server can make access-validation decisions without being able to use other services that are using the client's security context.
			/// </summary>
			SecurityIdentification,
			/// <summary>
			///   The server process can impersonate the client's security context on its local system. The server cannot impersonate the client on remote systems.
			/// </summary>
			SecurityImpersonation,
			/// <summary>
			///   The server process can impersonate the client's security context on remote systems.
			/// </summary>
			SecurityDelegation
		}

		#endregion // Access tokens.


		#region Registry.

		/// <summary>
		///   Determines the behavior of <see cref="RegLoadMUIString" />.
		/// </summary>
		[Flags]
		public enum RegistryLoadMuiStringOptions : uint
		{
			None = 0,
			/// <summary>
			///   The string is truncated to fit the available size of the output buffer. If this flag is specified, copiedDataSize must be NULL.
			/// </summary>
			Truncate = 1
		}

		#endregion // Registry.
	}
}
