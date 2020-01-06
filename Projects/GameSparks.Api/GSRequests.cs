using System;
using System.Collections.Generic;

using GameSparks.Core;
using GameSparks.Api.Responses;

namespace GameSparks.Api.Requests
{	
	
	/// <summary>
	/// Accepts a challenge that has been issued to the current player.}
	/// </summary>
	public class AcceptChallengeRequest : GSTypedRequest<AcceptChallengeRequest,AcceptChallengeResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public AcceptChallengeRequest() : base("AcceptChallengeRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public AcceptChallengeRequest(GSInstance instance) : base(instance, "AcceptChallengeRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AcceptChallengeResponse (response);
		}
		

		/// <summary>
		/// The ID of the challenge
		/// </summary>
		public AcceptChallengeRequest SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		/// <summary>
		/// An optional message to send with the challenge
		/// </summary>
		public AcceptChallengeRequest SetMessage( String message )
		{
			request.AddString("message", message);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Retrieves the details of the current authenticated player.}
	/// </summary>
	public class AccountDetailsRequest : GSTypedRequest<AccountDetailsRequest,AccountDetailsResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public AccountDetailsRequest() : base("AccountDetailsRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public AccountDetailsRequest(GSInstance instance) : base(instance, "AccountDetailsRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AccountDetailsResponse (response);
		}
		

				
	}
	
	
	/// <summary>
	/// Processes the receipt from an Amazon in app purchase.}
	/// The GameSparks platform will validate the amazonUserId and receiptId with Amazon using the Amazon Purchase Secret configured against the game.}
	/// The receiptId in the data will be recorded and the request will be rejected if the receiptId has previously been processed, this prevents replay attacks.}
	/// Once verfied, the players account will be credited with the Virtual Good, or Virtual Currency the purchase contains. The virtual good will be looked up by matching the productId in the receipt with the 'Amazon Product Id' configured against the virtual good.}
	/// </summary>
	public class AmazonBuyGoodsRequest : GSTypedRequest<AmazonBuyGoodsRequest,BuyVirtualGoodResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public AmazonBuyGoodsRequest() : base("AmazonBuyGoodsRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public AmazonBuyGoodsRequest(GSInstance instance) : base(instance, "AmazonBuyGoodsRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new BuyVirtualGoodResponse (response);
		}
		

		/// <summary>
		/// The userId obtained from the UserData within a PurchaseResponse
		/// </summary>
		public AmazonBuyGoodsRequest SetAmazonUserId( String amazonUserId )
		{
			request.AddString("amazonUserId", amazonUserId);
			return this;
		}
		/// <summary>
		/// The ISO 4217 currency code representing the real-world currency used for this transaction.
		/// </summary>
		public AmazonBuyGoodsRequest SetCurrencyCode( String currencyCode )
		{
			request.AddString("currencyCode", currencyCode);
			return this;
		}
		/// <summary>
		/// The receiptId obtained from the Receipt within a PurchaseResponse
		/// </summary>
		public AmazonBuyGoodsRequest SetReceiptId( String receiptId )
		{
			request.AddString("receiptId", receiptId);
			return this;
		}
		/// <summary>
		/// The price of this purchase
		/// </summary>
		public AmazonBuyGoodsRequest SetSubUnitPrice( double subUnitPrice )
		{
			request.AddNumber("subUnitPrice", subUnitPrice);
			return this;
		}
		/// <summary>
		/// If set to true, the transactionId from this receipt will not be globally valdidated, this will mean replays between players are possible.
		/// It will only validate the transactionId has not been used by this player before.
		/// </summary>
		public AmazonBuyGoodsRequest SetUniqueTransactionByPlayer( bool uniqueTransactionByPlayer )
		{
			request.AddBoolean("uniqueTransactionByPlayer", uniqueTransactionByPlayer);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows an Amazon access token to be used as an authentication mechanism.}
	/// Once authenticated the platform can determine the current players details from the Amazon platform and store them within GameSparks.}
	/// If the Amazon user is already linked to a player, the current session will switch to the linked player.}
	/// If the current player has previously created an account using either DeviceAuthentictionRequest or RegistrationRequest AND the Amazon user is not already registered with the game, the Amazon user will be linked to the current player.}
	/// If the current player has not authenticated and the Amazon user is not known, a new player will be created using the Amazon details and the session will be authenticated against the new player.}
	/// If the Amazon user is already known, the session will switch to being the previously created user.}
	/// </summary>
	public class AmazonConnectRequest : GSTypedRequest<AmazonConnectRequest,AuthenticationResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public AmazonConnectRequest() : base("AmazonConnectRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public AmazonConnectRequest(GSInstance instance) : base(instance, "AmazonConnectRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AuthenticationResponse (response);
		}
		

		/// <summary>
		/// The access token is used by the client to make authenticated requests on behalf of the end user.
		/// </summary>
		public AmazonConnectRequest SetAccessToken( String accessToken )
		{
			request.AddString("accessToken", accessToken);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if a new player would have been registered, rather than creating the player.  Defaults to false.
		/// </summary>
		public AmazonConnectRequest SetDoNotCreateNewPlayer( bool doNotCreateNewPlayer )
		{
			request.AddBoolean("doNotCreateNewPlayer", doNotCreateNewPlayer);
			return this;
		}
		/// <summary>
		/// Indicates that the server should not try to link the external profile with the current player.  If false, links the external profile to the currently signed in player.  If true, creates a new player and links the external profile to them.  Defaults to false.
		/// </summary>
		public AmazonConnectRequest SetDoNotLinkToCurrentPlayer( bool doNotLinkToCurrentPlayer )
		{
			request.AddBoolean("doNotLinkToCurrentPlayer", doNotLinkToCurrentPlayer);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if an account switch would have occurred, rather than switching automatically.  Defaults to false.
		/// </summary>
		public AmazonConnectRequest SetErrorOnSwitch( bool errorOnSwitch )
		{
			request.AddBoolean("errorOnSwitch", errorOnSwitch);
			return this;
		}
		/// <summary>
		/// An optional segment configuration for this request.
		/// If this request creates a new player on the gamesparks platform, the segments of the new player will match the values provided
		/// </summary>
		public AmazonConnectRequest SetSegments( GSRequestData segments )
		{
			request.AddObject("segments", segments);
			return this;
		}
		/// <summary>
		/// Indicates that the server should switch to the supplied profile if it isalready associated to a player. Defaults to false.
		/// </summary>
		public AmazonConnectRequest SetSwitchIfPossible( bool switchIfPossible )
		{
			request.AddBoolean("switchIfPossible", switchIfPossible);
			return this;
		}
		/// <summary>
		/// Indicates that the associated players displayName should be kept in syn with this profile when it's updated by the external provider.
		/// </summary>
		public AmazonConnectRequest SetSyncDisplayName( bool syncDisplayName )
		{
			request.AddBoolean("syncDisplayName", syncDisplayName);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Records some custom analytical data.}
	/// Simple analytics, where you just need to track the number of times something happened, just take a key parameter. We'll record the players id against the data to allow you to report on averages per user}
	/// Timed analytics allow you to send start and end timer requests, and with this data GameSparks can track the length of time something takes.}
	/// If an end request is sent without a matching start timer the request will fail silently and your analytics data might not contain what you expect.}
	/// If both start and end are supplied, the request will be treated as a start timer.}
	/// An additional data payload can be attached to the event for advanced reporting. This data can be a string, number or JSON object.}
	/// If a second start timer is created using a key that has already had a start timer created without an end, the previous one will be marked as abandoned.}
	/// </summary>
	public class AnalyticsRequest : GSTypedRequest<AnalyticsRequest,AnalyticsResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public AnalyticsRequest() : base("AnalyticsRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public AnalyticsRequest(GSInstance instance) : base(instance, "AnalyticsRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AnalyticsResponse (response);
		}
		

		/// <summary>
		/// Custom data payload
		/// </summary>
		public AnalyticsRequest SetData( GSRequestData data )
		{
			request.AddObject("data", data);
			return this;
		}
		/// <summary>
		/// Use the value true to indicate it's an end timer
		/// </summary>
		public AnalyticsRequest SetEnd( bool end )
		{
			request.AddBoolean("end", end);
			return this;
		}
		/// <summary>
		/// The key you want to track this analysis with.
		/// </summary>
		public AnalyticsRequest SetKey( String key )
		{
			request.AddString("key", key);
			return this;
		}
		/// <summary>
		/// Use the value true to indicate it's a start timer
		/// </summary>
		public AnalyticsRequest SetStart( bool start )
		{
			request.AddBoolean("start", start);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Returns leaderboard data that is adjacent to the currently signed in player's position within the given leaderboard.}
	/// </summary>
	public class AroundMeLeaderboardRequest : GSTypedRequest<AroundMeLeaderboardRequest,AroundMeLeaderboardResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public AroundMeLeaderboardRequest() : base("AroundMeLeaderboardRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public AroundMeLeaderboardRequest(GSInstance instance) : base(instance, "AroundMeLeaderboardRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AroundMeLeaderboardResponse (response);
		}
		

		/// <summary>
		/// The challenge instance to get the leaderboard data for
		/// </summary>
		public AroundMeLeaderboardRequest SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		/// <summary>
		/// An optional filter on the customIds.
		/// If this request does not contain a custonIdFilter or if it is a partial filter, 
		/// the leaderboard entries around the highest score for the given constraints will be returned.
		/// </summary>
		public AroundMeLeaderboardRequest SetCustomIdFilter( GSRequestData customIdFilter )
		{
			request.AddObject("customIdFilter", customIdFilter);
			return this;
		}
		/// <summary>
		/// The default behaviour on a social request is to error if the player has no friends (NOTSOCIAL).  Set this flag to suppress that error and return the player's leaderboard entry instead.
		/// </summary>
		public AroundMeLeaderboardRequest SetDontErrorOnNotSocial( bool dontErrorOnNotSocial )
		{
			request.AddBoolean("dontErrorOnNotSocial", dontErrorOnNotSocial);
			return this;
		}
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public AroundMeLeaderboardRequest SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public AroundMeLeaderboardRequest SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public AroundMeLeaderboardRequest SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		/// <summary>
		/// Returns the leaderboard excluding the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest SetInverseSocial( bool inverseSocial )
		{
			request.AddBoolean("inverseSocial", inverseSocial);
			return this;
		}
		/// <summary>
		/// The short code of the leaderboard
		/// </summary>
		public AroundMeLeaderboardRequest SetLeaderboardShortCode( String leaderboardShortCode )
		{
			request.AddString("leaderboardShortCode", leaderboardShortCode);
			return this;
		}
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public AroundMeLeaderboardRequest SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public AroundMeLeaderboardRequest SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Provides authentication using a username/password combination.}
	/// The username will have been previously created using a RegistrationRequest.}
	/// </summary>
	public class AuthenticationRequest : GSTypedRequest<AuthenticationRequest,AuthenticationResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public AuthenticationRequest() : base("AuthenticationRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public AuthenticationRequest(GSInstance instance) : base(instance, "AuthenticationRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AuthenticationResponse (response);
		}
		

		/// <summary>
		/// The previously registered password
		/// </summary>
		public AuthenticationRequest SetPassword( String password )
		{
			request.AddString("password", password);
			return this;
		}
		/// <summary>
		/// The previously registered player name
		/// </summary>
		public AuthenticationRequest SetUserName( String userName )
		{
			request.AddString("userName", userName);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Performs a request for multiple players.}
	/// </summary>
	public class BatchAdminRequest : GSTypedRequest<BatchAdminRequest,BatchAdminResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public BatchAdminRequest() : base("BatchAdminRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public BatchAdminRequest(GSInstance instance) : base(instance, "BatchAdminRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new BatchAdminResponse (response);
		}
		

		/// <summary>
		/// The players to run the request for.
		/// </summary>
		public BatchAdminRequest SetPlayerIds( List<string> playerIds )
		{
			request.AddStringList("playerIds", playerIds);
			return this;
		}
		/// <summary>
		/// The request to be run for each player.
		/// </summary>
		public BatchAdminRequest SetRequest( GSRequestData request )
		{
			request.AddObject("request", request);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Purchases a virtual good with an in game currency. Once purchased the virtual good will be added to the players account.}
	/// </summary>
	public class BuyVirtualGoodsRequest : GSTypedRequest<BuyVirtualGoodsRequest,BuyVirtualGoodResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public BuyVirtualGoodsRequest() : base("BuyVirtualGoodsRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public BuyVirtualGoodsRequest(GSInstance instance) : base(instance, "BuyVirtualGoodsRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new BuyVirtualGoodResponse (response);
		}
		

		/// <summary>
		/// The short code of the currency to use
		/// </summary>
		public BuyVirtualGoodsRequest SetCurrencyShortCode( String currencyShortCode )
		{
			request.AddString("currencyShortCode", currencyShortCode);
			return this;
		}
		/// <summary>
		/// Which virtual currency to use. (1 to 6)
		/// </summary>
		public BuyVirtualGoodsRequest SetCurrencyType( long currencyType )
		{
			request.AddNumber("currencyType", currencyType);
			return this;
		}
		/// <summary>
		/// The number of items to purchase
		/// </summary>
		public BuyVirtualGoodsRequest SetQuantity( long quantity )
		{
			request.AddNumber("quantity", quantity);
			return this;
		}
		/// <summary>
		/// The short code of the virtual good to be purchased
		/// </summary>
		public BuyVirtualGoodsRequest SetShortCode( String shortCode )
		{
			request.AddString("shortCode", shortCode);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Cancel one or more bulk jobs.}
	/// </summary>
	public class CancelBulkJobAdminRequest : GSTypedRequest<CancelBulkJobAdminRequest,CancelBulkJobAdminResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public CancelBulkJobAdminRequest() : base("CancelBulkJobAdminRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public CancelBulkJobAdminRequest(GSInstance instance) : base(instance, "CancelBulkJobAdminRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new CancelBulkJobAdminResponse (response);
		}
		

		/// <summary>
		/// The IDs of existing bulk jobs to cancel
		/// </summary>
		public CancelBulkJobAdminRequest SetBulkJobIds( List<string> bulkJobIds )
		{
			request.AddStringList("bulkJobIds", bulkJobIds);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Change the details of the currently signed in Player.}
	/// </summary>
	public class ChangeUserDetailsRequest : GSTypedRequest<ChangeUserDetailsRequest,ChangeUserDetailsResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ChangeUserDetailsRequest() : base("ChangeUserDetailsRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ChangeUserDetailsRequest(GSInstance instance) : base(instance, "ChangeUserDetailsRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new ChangeUserDetailsResponse (response);
		}
		

		/// <summary>
		/// The new display name to set in the player data.
		/// </summary>
		public ChangeUserDetailsRequest SetDisplayName( String displayName )
		{
			request.AddString("displayName", displayName);
			return this;
		}
		/// <summary>
		/// The new language code to set in the player data.
		/// </summary>
		public ChangeUserDetailsRequest SetLanguage( String language )
		{
			request.AddString("language", language);
			return this;
		}
		/// <summary>
		/// The new password to set in the player data.
		/// </summary>
		public ChangeUserDetailsRequest SetNewPassword( String newPassword )
		{
			request.AddString("newPassword", newPassword);
			return this;
		}
		/// <summary>
		/// The player's existing password. If supplied it will be checked against the password stored in the player data. This allows you re-authenticate the player making the change.
		/// </summary>
		public ChangeUserDetailsRequest SetOldPassword( String oldPassword )
		{
			request.AddString("oldPassword", oldPassword);
			return this;
		}
		/// <summary>
		/// The new userName with which this player will sign in.  If the player currently authenticates using device authentication this will upgrade their account and require them to use username and password authentication from now on.
		/// </summary>
		public ChangeUserDetailsRequest SetUserName( String userName )
		{
			request.AddString("userName", userName);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Sends a message to all players involved in the challenge. The current player must be involved in the challenge for the message to be sent.}
	/// As the message is sent to all players, the current player will also see details of the message in the response. Read the section on response message aggregation for a description of this.}
	/// </summary>
	public class ChatOnChallengeRequest : GSTypedRequest<ChatOnChallengeRequest,ChatOnChallengeResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ChatOnChallengeRequest() : base("ChatOnChallengeRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ChatOnChallengeRequest(GSInstance instance) : base(instance, "ChatOnChallengeRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new ChatOnChallengeResponse (response);
		}
		

		/// <summary>
		/// The ID of the challenge
		/// </summary>
		public ChatOnChallengeRequest SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		/// <summary>
		/// An optional message to send with the challenge
		/// </summary>
		public ChatOnChallengeRequest SetMessage( String message )
		{
			request.AddString("message", message);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Consumes a given amount of the specified virtual good.}
	/// </summary>
	public class ConsumeVirtualGoodRequest : GSTypedRequest<ConsumeVirtualGoodRequest,ConsumeVirtualGoodResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ConsumeVirtualGoodRequest() : base("ConsumeVirtualGoodRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ConsumeVirtualGoodRequest(GSInstance instance) : base(instance, "ConsumeVirtualGoodRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new ConsumeVirtualGoodResponse (response);
		}
		

		/// <summary>
		/// The amount of virtual goods to be consumed
		/// </summary>
		public ConsumeVirtualGoodRequest SetQuantity( long quantity )
		{
			request.AddNumber("quantity", quantity);
			return this;
		}
		/// <summary>
		/// The short code of the virtual good to be consumed
		/// </summary>
		public ConsumeVirtualGoodRequest SetShortCode( String shortCode )
		{
			request.AddString("shortCode", shortCode);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Issues a challenge to a group of players from the currently signed in player.}
	/// The endTime field must be present unless the challenge template has an achievement set in the 'First to Achievement' field.}
	/// The usersToChallenge field must be present for this request if the acessType is PRIVATE (which is the default).}
	/// </summary>
	public class CreateChallengeRequest : GSTypedRequest<CreateChallengeRequest,CreateChallengeResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public CreateChallengeRequest() : base("CreateChallengeRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public CreateChallengeRequest(GSInstance instance) : base(instance, "CreateChallengeRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new CreateChallengeResponse (response);
		}
		

		/// <summary>
		/// Who can join this challenge. Either PUBLIC, PRIVATE or FRIENDS
		/// </summary>
		public CreateChallengeRequest SetAccessType( String accessType )
		{
			request.AddString("accessType", accessType);
			return this;
		}
		/// <summary>
		/// Whether this challenge should automatically start when a new player joins and maxPlayers is reached
		/// </summary>
		public CreateChallengeRequest SetAutoStartJoinedChallengeOnMaxPlayers( bool autoStartJoinedChallengeOnMaxPlayers )
		{
			request.AddBoolean("autoStartJoinedChallengeOnMaxPlayers", autoStartJoinedChallengeOnMaxPlayers);
			return this;
		}
		/// <summary>
		/// An optional message to include with the challenge
		/// </summary>
		public CreateChallengeRequest SetChallengeMessage( String challengeMessage )
		{
			request.AddString("challengeMessage", challengeMessage);
			return this;
		}
		/// <summary>
		/// The short code of the challenge
		/// </summary>
		public CreateChallengeRequest SetChallengeShortCode( String challengeShortCode )
		{
			request.AddString("challengeShortCode", challengeShortCode);
			return this;
		}
		/// <summary>
		/// The ammount of currency type 1 that the player is wagering on this challenge
		/// </summary>
		public CreateChallengeRequest SetCurrency1Wager( long currency1Wager )
		{
			request.AddNumber("currency1Wager", currency1Wager);
			return this;
		}
		/// <summary>
		/// The amount of currency type 2 that the player is wagering on this challenge
		/// </summary>
		public CreateChallengeRequest SetCurrency2Wager( long currency2Wager )
		{
			request.AddNumber("currency2Wager", currency2Wager);
			return this;
		}
		/// <summary>
		/// The amount of currency type 3 that the player is wagering on this challenge
		/// </summary>
		public CreateChallengeRequest SetCurrency3Wager( long currency3Wager )
		{
			request.AddNumber("currency3Wager", currency3Wager);
			return this;
		}
		/// <summary>
		/// The amount of currency type 4 that the player is wagering on this challenge
		/// </summary>
		public CreateChallengeRequest SetCurrency4Wager( long currency4Wager )
		{
			request.AddNumber("currency4Wager", currency4Wager);
			return this;
		}
		/// <summary>
		/// The amount of currency type 5 that the player is wagering on this challenge
		/// </summary>
		public CreateChallengeRequest SetCurrency5Wager( long currency5Wager )
		{
			request.AddNumber("currency5Wager", currency5Wager);
			return this;
		}
		/// <summary>
		/// The amount of currency type 6 that the player is wagering on this challenge
		/// </summary>
		public CreateChallengeRequest SetCurrency6Wager( long currency6Wager )
		{
			request.AddNumber("currency6Wager", currency6Wager);
			return this;
		}
		/// <summary>
		/// A JSON object containing the amounts of named currencies that the player is wagering on this challenge
		/// </summary>
		public CreateChallengeRequest SetCurrencyWagers( GSRequestData currencyWagers )
		{
			request.AddObject("currencyWagers", currencyWagers);
			return this;
		}
		/// <summary>
		/// Criteria for who can and cannot find and join this challenge (when the accessType is PUBLIC or FRIENDS).
		/// Currently supports a field <i>segments</i> that contains segment type against single (where that segment value is required) or multiple (where one of the specified values is required) segment values.
		/// For each segment type a player must have one of the specified values in order to be considered eligible.
		/// </summary>
		public CreateChallengeRequest SetEligibilityCriteria( GSRequestData eligibilityCriteria )
		{
			request.AddObject("eligibilityCriteria", eligibilityCriteria);
			return this;
		}
		/// <summary>
		/// The time at which this challenge will end. This is required when the challenge is not linked to an achievement
		/// </summary>
		public CreateChallengeRequest SetEndTime( DateTime endTime )
		{
			request.AddDate("endTime", endTime);
			return this;
		}
		/// <summary>
		/// The latest time that players can join this challenge
		/// </summary>
		public CreateChallengeRequest SetExpiryTime( DateTime expiryTime )
		{
			request.AddDate("expiryTime", expiryTime);
			return this;
		}
		/// <summary>
		/// The maximum number of attempts 
		/// </summary>
		public CreateChallengeRequest SetMaxAttempts( long maxAttempts )
		{
			request.AddNumber("maxAttempts", maxAttempts);
			return this;
		}
		/// <summary>
		/// The maximum number of players that are allowed to join this challenge
		/// </summary>
		public CreateChallengeRequest SetMaxPlayers( long maxPlayers )
		{
			request.AddNumber("maxPlayers", maxPlayers);
			return this;
		}
		/// <summary>
		/// The minimum number of players that are allowed to join this challenge
		/// </summary>
		public CreateChallengeRequest SetMinPlayers( long minPlayers )
		{
			request.AddNumber("minPlayers", minPlayers);
			return this;
		}
		/// <summary>
		/// If True  no messaging is triggered
		/// </summary>
		public CreateChallengeRequest SetSilent( bool silent )
		{
			request.AddBoolean("silent", silent);
			return this;
		}
		/// <summary>
		/// The time at which this challenge will begin
		/// </summary>
		public CreateChallengeRequest SetStartTime( DateTime startTime )
		{
			request.AddDate("startTime", startTime);
			return this;
		}
		/// <summary>
		/// A player id or an array of player ids who will recieve this challenge
		/// </summary>
		public CreateChallengeRequest SetUsersToChallenge( List<string> usersToChallenge )
		{
			request.AddStringList("usersToChallenge", usersToChallenge);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows a new team to be created.}
	/// </summary>
	public class CreateTeamRequest : GSTypedRequest<CreateTeamRequest,CreateTeamResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public CreateTeamRequest() : base("CreateTeamRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public CreateTeamRequest(GSInstance instance) : base(instance, "CreateTeamRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new CreateTeamResponse (response);
		}
		

		/// <summary>
		/// An optional teamId to use
		/// </summary>
		public CreateTeamRequest SetTeamId( String teamId )
		{
			request.AddString("teamId", teamId);
			return this;
		}
		/// <summary>
		/// A display name to use
		/// </summary>
		public CreateTeamRequest SetTeamName( String teamName )
		{
			request.AddString("teamName", teamName);
			return this;
		}
		/// <summary>
		/// The type of team to be created
		/// </summary>
		public CreateTeamRequest SetTeamType( String teamType )
		{
			request.AddString("teamType", teamType);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Declines a challenge that has been issued to the current player.}
	/// </summary>
	public class DeclineChallengeRequest : GSTypedRequest<DeclineChallengeRequest,DeclineChallengeResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public DeclineChallengeRequest() : base("DeclineChallengeRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public DeclineChallengeRequest(GSInstance instance) : base(instance, "DeclineChallengeRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new DeclineChallengeResponse (response);
		}
		

		/// <summary>
		/// The ID of the challenge
		/// </summary>
		public DeclineChallengeRequest SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		/// <summary>
		/// An optional message to send with the challenge
		/// </summary>
		public DeclineChallengeRequest SetMessage( String message )
		{
			request.AddString("message", message);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows a device id to be used to create an anonymous profile in the game.}
	/// This allows the player to be tracked and have data stored against them before using FacebookConnectRequest to create a full profile.}
	/// DeviceAuthenticationRequest should not be used in conjunction with RegistrationRequest as the two accounts will not be merged.}
	/// </summary>
	public class DeviceAuthenticationRequest : GSTypedRequest<DeviceAuthenticationRequest,AuthenticationResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public DeviceAuthenticationRequest() : base("DeviceAuthenticationRequest"){
			request.AddString("deviceId", GS.GSPlatform.DeviceId);
			request.AddString("deviceOS", GS.GSPlatform.DeviceOS);
			request.AddString("deviceType", GS.GSPlatform.DeviceType);
			request.AddString("operatingSystem", GS.GSPlatform.Platform);

		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public DeviceAuthenticationRequest(GSInstance instance) : base(instance, "DeviceAuthenticationRequest"){
			request.AddString("deviceId", instance.GSPlatform.DeviceId);
			request.AddString("deviceOS", instance.GSPlatform.DeviceOS);
			request.AddString("deviceType", instance.GSPlatform.DeviceType);
			request.AddString("operatingSystem", instance.GSPlatform.Platform);

		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AuthenticationResponse (response);
		}
		

		/// <summary>
		/// An optional displayname for the player
		/// </summary>
		public DeviceAuthenticationRequest SetDisplayName( String displayName )
		{
			request.AddString("displayName", displayName);
			return this;
		}
		/// <summary>
		/// An optional segment configuration for this request.
		/// If this request reates a new player on the gamesparks platform, the segments of the new player will match the values provided
		/// </summary>
		public DeviceAuthenticationRequest SetSegments( GSRequestData segments )
		{
			request.AddObject("segments", segments);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows a message to be dismissed. Once dismissed the message will no longer appear in either ListMessageResponse or ListMessageSummaryResponse.}
	/// </summary>
	public class DismissMessageRequest : GSTypedRequest<DismissMessageRequest,DismissMessageResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public DismissMessageRequest() : base("DismissMessageRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public DismissMessageRequest(GSInstance instance) : base(instance, "DismissMessageRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new DismissMessageResponse (response);
		}
		

		/// <summary>
		/// The messageId of the message to dismiss
		/// </summary>
		public DismissMessageRequest SetMessageId( String messageId )
		{
			request.AddString("messageId", messageId);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows multiple messages to be dismissed. Once dismissed the messages will no longer appear in either ListMessageResponse or ListMessageSummaryResponse.}
	/// </summary>
	public class DismissMultipleMessagesRequest : GSTypedRequest<DismissMultipleMessagesRequest,DismissMultipleMessagesResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public DismissMultipleMessagesRequest() : base("DismissMultipleMessagesRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public DismissMultipleMessagesRequest(GSInstance instance) : base(instance, "DismissMultipleMessagesRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new DismissMultipleMessagesResponse (response);
		}
		

		/// <summary>
		/// The list of the messageIds to dismiss
		/// </summary>
		public DismissMultipleMessagesRequest SetMessageIds( List<string> messageIds )
		{
			request.AddStringList("messageIds", messageIds);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows a player to drop a team.}
	/// </summary>
	public class DropTeamRequest : GSTypedRequest<DropTeamRequest,DropTeamResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public DropTeamRequest() : base("DropTeamRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public DropTeamRequest(GSInstance instance) : base(instance, "DropTeamRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new DropTeamResponse (response);
		}
		

		/// <summary>
		/// The team owner to find, used in combination with teamType. If not supplied the current players id will be used
		/// </summary>
		public DropTeamRequest SetOwnerId( String ownerId )
		{
			request.AddString("ownerId", ownerId);
			return this;
		}
		/// <summary>
		/// The teamId to find (may be null if teamType supplied)
		/// </summary>
		public DropTeamRequest SetTeamId( String teamId )
		{
			request.AddString("teamId", teamId);
			return this;
		}
		/// <summary>
		/// The teamType to find, used in combination with the current player, or the player defined by ownerId
		/// </summary>
		public DropTeamRequest SetTeamType( String teamType )
		{
			request.AddString("teamType", teamType);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Records the end of the current player's active session.}
	/// The SDK will automatically create a new session ID when the application is started, this method can be useful to call when the app goes into the background to allow reporting on player session length.}
	/// </summary>
	public class EndSessionRequest : GSTypedRequest<EndSessionRequest,EndSessionResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public EndSessionRequest() : base("EndSessionRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public EndSessionRequest(GSInstance instance) : base(instance, "EndSessionRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new EndSessionResponse (response);
		}
		

				
	}
	
	
	/// <summary>
	/// Allows either a Facebook access token, or a Facebook authorization code to be used as an authentication mechanism.}
	/// Once authenticated the platform can determine the current players details from the Facebook platform and store them within GameSparks.}
	/// GameSparks will determine the player's friends and whether any of them are currently registered with the game.}
	/// If the Facebook user is already linked to a player, the current session will switch to the linked player.}
	/// If the current player has previously created an account using either DeviceAuthenticationRequest or RegistrationRequest AND the Facebook user is not already registered with the game, the Facebook user will be linked to the current player.}
	/// If the current player has not authenticated and the Facebook user is not known, a new player will be created using the Facebook details and the session will be authenticated against the new player.}
	/// If the Facebook user is already known, the session will switch to being the previously created user.}
	/// </summary>
	public class FacebookConnectRequest : GSTypedRequest<FacebookConnectRequest,AuthenticationResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public FacebookConnectRequest() : base("FacebookConnectRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public FacebookConnectRequest(GSInstance instance) : base(instance, "FacebookConnectRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AuthenticationResponse (response);
		}
		

		/// <summary>
		/// The access token is used by the client to make authenticated requests on behalf of the end user.
		/// It has a longer lifetime than the authorization code, typically on the order of minutes or hours.
		/// When the access token expires, attempts to use it will fail, and a new access token must be obtained via a refresh token.
		/// </summary>
		public FacebookConnectRequest SetAccessToken( String accessToken )
		{
			request.AddString("accessToken", accessToken);
			return this;
		}
		/// <summary>
		/// An authorization code is a short-lived token representing the user's access grant, created by the authorization server and passed to the client application via the browser.
		/// The client application sends the authorization code to the authorization server to obtain an access token and, optionally, a refresh token.
		/// </summary>
		public FacebookConnectRequest SetCode( String code )
		{
			request.AddString("code", code);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if a new player would have been registered, rather than creating the player.  Defaults to false.
		/// </summary>
		public FacebookConnectRequest SetDoNotCreateNewPlayer( bool doNotCreateNewPlayer )
		{
			request.AddBoolean("doNotCreateNewPlayer", doNotCreateNewPlayer);
			return this;
		}
		/// <summary>
		/// Indicates that the server should not try to link the external profile with the current player.  If false, links the external profile to the currently signed in player.  If true, creates a new player and links the external profile to them.  Defaults to false.
		/// </summary>
		public FacebookConnectRequest SetDoNotLinkToCurrentPlayer( bool doNotLinkToCurrentPlayer )
		{
			request.AddBoolean("doNotLinkToCurrentPlayer", doNotLinkToCurrentPlayer);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if an account switch would have occurred, rather than switching automatically.  Defaults to false.
		/// </summary>
		public FacebookConnectRequest SetErrorOnSwitch( bool errorOnSwitch )
		{
			request.AddBoolean("errorOnSwitch", errorOnSwitch);
			return this;
		}
		/// <summary>
		/// An optional segment configuration for this request.
		/// If this request creates a new player on the gamesparks platform, the segments of the new player will match the values provided
		/// </summary>
		public FacebookConnectRequest SetSegments( GSRequestData segments )
		{
			request.AddObject("segments", segments);
			return this;
		}
		/// <summary>
		/// Indicates that the server should switch to the supplied profile if it isalready associated to a player. Defaults to false.
		/// </summary>
		public FacebookConnectRequest SetSwitchIfPossible( bool switchIfPossible )
		{
			request.AddBoolean("switchIfPossible", switchIfPossible);
			return this;
		}
		/// <summary>
		/// Indicates that the associated players displayName should be kept in syn with this profile when it's updated by the external provider.
		/// </summary>
		public FacebookConnectRequest SetSyncDisplayName( bool syncDisplayName )
		{
			request.AddBoolean("syncDisplayName", syncDisplayName);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows a player to find challenges that they are eligible to join.}
	/// </summary>
	public class FindChallengeRequest : GSTypedRequest<FindChallengeRequest,FindChallengeResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public FindChallengeRequest() : base("FindChallengeRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public FindChallengeRequest(GSInstance instance) : base(instance, "FindChallengeRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new FindChallengeResponse (response);
		}
		

		/// <summary>
		/// The type of challenge to find, either PUBLIC or FRIENDS.  Defaults to FRIENDS
		/// </summary>
		public FindChallengeRequest SetAccessType( String accessType )
		{
			request.AddString("accessType", accessType);
			return this;
		}
		/// <summary>
		/// The number of challenges to return (MAX=50)
		/// </summary>
		public FindChallengeRequest SetCount( long count )
		{
			request.AddNumber("count", count);
			return this;
		}
		/// <summary>
		/// Optional.  Allows the current player's eligibility to be overridden by what is provided here.
		/// </summary>
		public FindChallengeRequest SetEligibility( GSRequestData eligibility )
		{
			request.AddObject("eligibility", eligibility);
			return this;
		}
		/// <summary>
		/// The offset to start from when returning challenges (used for paging)
		/// </summary>
		public FindChallengeRequest SetOffset( long offset )
		{
			request.AddNumber("offset", offset);
			return this;
		}
		/// <summary>
		/// Optional shortCodes to filter the results by challenge type
		/// </summary>
		public FindChallengeRequest SetShortCode( List<string> shortCode )
		{
			request.AddStringList("shortCode", shortCode);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// @Deprecated. Use MatchmakingRequest instead.}
	/// Find a match for this player, using the given skill and matchShortCode.}
	/// Players looking for a match using the same matchShortCode will be considered for a match, based on the matchConfig.}
	/// Each player must match the other for the match to be found.}
	/// </summary>
	public class FindMatchRequest : GSTypedRequest<FindMatchRequest,FindMatchResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public FindMatchRequest() : base("FindMatchRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public FindMatchRequest(GSInstance instance) : base(instance, "FindMatchRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new FindMatchResponse (response);
		}
		

		/// <summary>
		/// The action to take on the already in-flight request for this match. Currently supported actions are: 'cancel'
		/// </summary>
		public FindMatchRequest SetAction( String action )
		{
			request.AddString("action", action);
			return this;
		}
		/// <summary>
		/// Optional. Players will be grouped based on the distinct value passed in here, only players in the same group can be matched together
		/// </summary>
		public FindMatchRequest SetMatchGroup( String matchGroup )
		{
			request.AddString("matchGroup", matchGroup);
			return this;
		}
		/// <summary>
		/// The shortCode of the match type this player is registering for
		/// </summary>
		public FindMatchRequest SetMatchShortCode( String matchShortCode )
		{
			request.AddString("matchShortCode", matchShortCode);
			return this;
		}
		/// <summary>
		/// The skill of the player looking for a match
		/// </summary>
		public FindMatchRequest SetSkill( long skill )
		{
			request.AddNumber("skill", skill);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Find other pending matches that will match this player's previously submitted MatchmakingRequest.}
	/// Used for manual matching of players, where you want control over which pending match should be chosen.}
	/// Each player must match the other for the pending match to be found.}
	/// </summary>
	public class FindPendingMatchesRequest : GSTypedRequest<FindPendingMatchesRequest,FindPendingMatchesResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public FindPendingMatchesRequest() : base("FindPendingMatchesRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public FindPendingMatchesRequest(GSInstance instance) : base(instance, "FindPendingMatchesRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new FindPendingMatchesResponse (response);
		}
		

		/// <summary>
		/// Optional. The matchGroup of the match this player previously registeredfor
		/// </summary>
		public FindPendingMatchesRequest SetMatchGroup( String matchGroup )
		{
			request.AddString("matchGroup", matchGroup);
			return this;
		}
		/// <summary>
		/// The shortCode of the match this player previously registered for
		/// </summary>
		public FindPendingMatchesRequest SetMatchShortCode( String matchShortCode )
		{
			request.AddString("matchShortCode", matchShortCode);
			return this;
		}
		/// <summary>
		/// Optional. The maximum number of pending matches to return (default=10)
		/// </summary>
		public FindPendingMatchesRequest SetMaxMatchesToFind( long maxMatchesToFind )
		{
			request.AddNumber("maxMatchesToFind", maxMatchesToFind);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows an Apple account that has GameCenter to be used as an authentication mechanism.}
	/// The request must supply the GameCenter user details, such as the player id and username.}
	/// If the GameCenter user is already linked to a player, the current session will switch to the linked player.}
	/// If the current player has previously created an account using either DeviceAuthentictionRequest or RegistrationRequest AND the GameCenter user is not already registered with the game, the GameCenter user will be linked to the current player.}
	/// If the current player has not authenticated and the GameCenter user is not known, a new player will be created using the GameCenter details and the session will be authenticated against the new player.}
	/// If the GameCenter user is already known, the session will switch to being the previously created user.}
	/// This API call requires the output details from GKLocalPlayer.generateIdentityVerificationSignatureWithCompletionHandler on your iOS device}
	/// </summary>
	public class GameCenterConnectRequest : GSTypedRequest<GameCenterConnectRequest,AuthenticationResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GameCenterConnectRequest() : base("GameCenterConnectRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GameCenterConnectRequest(GSInstance instance) : base(instance, "GameCenterConnectRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AuthenticationResponse (response);
		}
		

		/// <summary>
		/// The display of the current player from GameCenter. This will be used as the displayName of the gamesparks player if created (or syncDisplayname is true)
		/// </summary>
		public GameCenterConnectRequest SetDisplayName( String displayName )
		{
			request.AddString("displayName", displayName);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if a new player would have been registered, rather than creating the player.  Defaults to false.
		/// </summary>
		public GameCenterConnectRequest SetDoNotCreateNewPlayer( bool doNotCreateNewPlayer )
		{
			request.AddBoolean("doNotCreateNewPlayer", doNotCreateNewPlayer);
			return this;
		}
		/// <summary>
		/// Indicates that the server should not try to link the external profile with the current player.  If false, links the external profile to the currently signed in player.  If true, creates a new player and links the external profile to them.  Defaults to false.
		/// </summary>
		public GameCenterConnectRequest SetDoNotLinkToCurrentPlayer( bool doNotLinkToCurrentPlayer )
		{
			request.AddBoolean("doNotLinkToCurrentPlayer", doNotLinkToCurrentPlayer);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if an account switch would have occurred, rather than switching automatically.  Defaults to false.
		/// </summary>
		public GameCenterConnectRequest SetErrorOnSwitch( bool errorOnSwitch )
		{
			request.AddBoolean("errorOnSwitch", errorOnSwitch);
			return this;
		}
		/// <summary>
		/// The game center id of the current player. This value obtained be obtained from GKLocalPlayer playerID
		/// </summary>
		public GameCenterConnectRequest SetExternalPlayerId( String externalPlayerId )
		{
			request.AddString("externalPlayerId", externalPlayerId);
			return this;
		}
		/// <summary>
		/// The url from where we will download the public key. This value should be obtained from generateIdentityVerificationSignatureWithCompletionHandler. 
		/// </summary>
		public GameCenterConnectRequest SetPublicKeyUrl( String publicKeyUrl )
		{
			request.AddString("publicKeyUrl", publicKeyUrl);
			return this;
		}
		/// <summary>
		/// The salt is needed in order to prevent request forgery. This value should be obtained from generateIdentityVerificationSignatureWithCompletionHandler and should be base64 encoded using [salt base64Encoding]
		/// </summary>
		public GameCenterConnectRequest SetSalt( String salt )
		{
			request.AddString("salt", salt);
			return this;
		}
		/// <summary>
		/// An optional segment configuration for this request.
		/// If this request creates a new player on the gamesparks platform, the segments of the new player will match the values provided
		/// </summary>
		public GameCenterConnectRequest SetSegments( GSRequestData segments )
		{
			request.AddObject("segments", segments);
			return this;
		}
		/// <summary>
		/// The signature is needed to validate that the request is genuine and that we can save the player. This value should be obtained from generateIdentityVerificationSignatureWithCompletionHandler and should be base64 encoded using [signature base64Encoding]
		/// </summary>
		public GameCenterConnectRequest SetSignature( String signature )
		{
			request.AddString("signature", signature);
			return this;
		}
		/// <summary>
		/// Indicates that the server should switch to the supplied profile if it isalready associated to a player. Defaults to false.
		/// </summary>
		public GameCenterConnectRequest SetSwitchIfPossible( bool switchIfPossible )
		{
			request.AddBoolean("switchIfPossible", switchIfPossible);
			return this;
		}
		/// <summary>
		/// Indicates that the associated players displayName should be kept in syn with this profile when it's updated by the external provider.
		/// </summary>
		public GameCenterConnectRequest SetSyncDisplayName( bool syncDisplayName )
		{
			request.AddBoolean("syncDisplayName", syncDisplayName);
			return this;
		}
		/// <summary>
		/// The timestamp is needed to validate the request signature. This value should be obtained from generateIdentityVerificationSignatureWithCompletionHandler
		/// </summary>
		public GameCenterConnectRequest SetTimestamp( long timestamp )
		{
			request.AddNumber("timestamp", timestamp);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Gets the details of a challenge. The current player must be involved in the challenge for the request to succeed.}
	/// </summary>
	public class GetChallengeRequest : GSTypedRequest<GetChallengeRequest,GetChallengeResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GetChallengeRequest() : base("GetChallengeRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GetChallengeRequest(GSInstance instance) : base(instance, "GetChallengeRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new GetChallengeResponse (response);
		}
		

		/// <summary>
		/// The ID of the challenge
		/// </summary>
		public GetChallengeRequest SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		/// <summary>
		/// An optional message to send with the challenge
		/// </summary>
		public GetChallengeRequest SetMessage( String message )
		{
			request.AddString("message", message);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Returns a secure, time sensitive url to allow the game to download a piece of downloadable content stored in the GameSparks platform.}
	/// </summary>
	public class GetDownloadableRequest : GSTypedRequest<GetDownloadableRequest,GetDownloadableResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GetDownloadableRequest() : base("GetDownloadableRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GetDownloadableRequest(GSInstance instance) : base(instance, "GetDownloadableRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new GetDownloadableResponse (response);
		}
		

		/// <summary>
		/// The short code of the Downloadable item
		/// </summary>
		public GetDownloadableRequest SetShortCode( String shortCode )
		{
			request.AddString("shortCode", shortCode);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Get the leaderboard entry data for the current player or a given player. }
	/// For each leaderboard it returns the hichest score the player has}
	/// </summary>
	public class GetLeaderboardEntriesRequest : GSTypedRequest<GetLeaderboardEntriesRequest,GetLeaderboardEntriesResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GetLeaderboardEntriesRequest() : base("GetLeaderboardEntriesRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GetLeaderboardEntriesRequest(GSInstance instance) : base(instance, "GetLeaderboardEntriesRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new GetLeaderboardEntriesResponse (response);
		}
		

		/// <summary>
		/// The challenge leaderboards to return entries for
		/// </summary>
		public GetLeaderboardEntriesRequest SetChallenges( List<string> challenges )
		{
			request.AddStringList("challenges", challenges);
			return this;
		}
		/// <summary>
		/// Returns the leaderboard excluding the player's social friends
		/// </summary>
		public GetLeaderboardEntriesRequest SetInverseSocial( bool inverseSocial )
		{
			request.AddBoolean("inverseSocial", inverseSocial);
			return this;
		}
		/// <summary>
		/// The list of leaderboards shortcodes
		/// </summary>
		public GetLeaderboardEntriesRequest SetLeaderboards( List<string> leaderboards )
		{
			request.AddStringList("leaderboards", leaderboards);
			return this;
		}
		/// <summary>
		/// The player id. Leave out to use the current player id
		/// </summary>
		public GetLeaderboardEntriesRequest SetPlayer( String player )
		{
			request.AddString("player", player);
			return this;
		}
		/// <summary>
		/// Set to true to include the player's game friends
		/// </summary>
		public GetLeaderboardEntriesRequest SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The types of team to apply this request to
		/// </summary>
		public GetLeaderboardEntriesRequest SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Returns the full details of a message.}
	/// </summary>
	public class GetMessageRequest : GSTypedRequest<GetMessageRequest,GetMessageResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GetMessageRequest() : base("GetMessageRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GetMessageRequest(GSInstance instance) : base(instance, "GetMessageRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new GetMessageResponse (response);
		}
		

		/// <summary>
		/// The messageId of the message retreive
		/// </summary>
		public GetMessageRequest SetMessageId( String messageId )
		{
			request.AddString("messageId", messageId);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Get the teams that the player is in. Can be filtered on team type and also on those teams that the player owns.}
	/// </summary>
	public class GetMyTeamsRequest : GSTypedRequest<GetMyTeamsRequest,GetMyTeamsResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GetMyTeamsRequest() : base("GetMyTeamsRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GetMyTeamsRequest(GSInstance instance) : base(instance, "GetMyTeamsRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new GetMyTeamsResponse (response);
		}
		

		/// <summary>
		/// Set to true to only get teams owned by the player
		/// </summary>
		public GetMyTeamsRequest SetOwnedOnly( bool ownedOnly )
		{
			request.AddBoolean("ownedOnly", ownedOnly);
			return this;
		}
		/// <summary>
		/// The type of teams to get
		/// </summary>
		public GetMyTeamsRequest SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Get the property for the given short Code.}
	/// </summary>
	public class GetPropertyRequest : GSTypedRequest<GetPropertyRequest,GetPropertyResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GetPropertyRequest() : base("GetPropertyRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GetPropertyRequest(GSInstance instance) : base(instance, "GetPropertyRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new GetPropertyResponse (response);
		}
		

		/// <summary>
		/// The shortCode of the property to return.
		/// </summary>
		public GetPropertyRequest SetPropertyShortCode( String propertyShortCode )
		{
			request.AddString("propertyShortCode", propertyShortCode);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Get the property set for the given short Code.}
	/// </summary>
	public class GetPropertySetRequest : GSTypedRequest<GetPropertySetRequest,GetPropertySetResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GetPropertySetRequest() : base("GetPropertySetRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GetPropertySetRequest(GSInstance instance) : base(instance, "GetPropertySetRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new GetPropertySetResponse (response);
		}
		

		/// <summary>
		/// The shortCode of the property set to return.
		/// </summary>
		public GetPropertySetRequest SetPropertySetShortCode( String propertySetShortCode )
		{
			request.AddString("propertySetShortCode", propertySetShortCode);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows the details of a team to be retrieved.}
	/// </summary>
	public class GetTeamRequest : GSTypedRequest<GetTeamRequest,GetTeamResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GetTeamRequest() : base("GetTeamRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GetTeamRequest(GSInstance instance) : base(instance, "GetTeamRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new GetTeamResponse (response);
		}
		

		/// <summary>
		/// The team owner to find, used in combination with teamType. If not supplied the current players id will be used
		/// </summary>
		public GetTeamRequest SetOwnerId( String ownerId )
		{
			request.AddString("ownerId", ownerId);
			return this;
		}
		/// <summary>
		/// The teamId to find (may be null if teamType supplied)
		/// </summary>
		public GetTeamRequest SetTeamId( String teamId )
		{
			request.AddString("teamId", teamId);
			return this;
		}
		/// <summary>
		/// The teamType to find, used in combination with the current player, or the player defined by ownerId
		/// </summary>
		public GetTeamRequest SetTeamType( String teamType )
		{
			request.AddString("teamType", teamType);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Returns a secure, time sensitive URL to allow the game to upload a piece of player content to the GameSparks platform.}
	/// </summary>
	public class GetUploadUrlRequest : GSTypedRequest<GetUploadUrlRequest,GetUploadUrlResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GetUploadUrlRequest() : base("GetUploadUrlRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GetUploadUrlRequest(GSInstance instance) : base(instance, "GetUploadUrlRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new GetUploadUrlResponse (response);
		}
		

		/// <summary>
		/// Optional meta data which is stored against the player's uploaded content
		/// </summary>
		public GetUploadUrlRequest SetUploadData( GSRequestData uploadData )
		{
			request.AddObject("uploadData", uploadData);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Returns a secure, time sensitive URL to a piece of content that was previously uploaded to the GameSparks platform by a player.}
	/// </summary>
	public class GetUploadedRequest : GSTypedRequest<GetUploadedRequest,GetUploadedResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GetUploadedRequest() : base("GetUploadedRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GetUploadedRequest(GSInstance instance) : base(instance, "GetUploadedRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new GetUploadedResponse (response);
		}
		

		/// <summary>
		/// The system generated id of the uploaded item
		/// </summary>
		public GetUploadedRequest SetUploadId( String uploadId )
		{
			request.AddString("uploadId", uploadId);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Processes the response from a Google Play in app purchase flow.}
	/// The GameSparks platform will validate the signature and signed data with the Google Play Public Key configured against the game.}
	/// The orderId in the data will be recorded and the request will be rejected if the orderId has previously been processed, this prevents replay attacks.}
	/// Once verfied, the players account will be credited with the Virtual Good, or Virtual Currency the purchase contains. The virtual good will be looked up by matching the productId in the signed data with the 'Google Product ID' configured against the virtual good.}
	/// It is critical that the signedData is sent exactly as it is returned form google, including any whitespace. Any modification of the signedData will cause the verification process to fail.}
	/// </summary>
	public class GooglePlayBuyGoodsRequest : GSTypedRequest<GooglePlayBuyGoodsRequest,BuyVirtualGoodResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GooglePlayBuyGoodsRequest() : base("GooglePlayBuyGoodsRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GooglePlayBuyGoodsRequest(GSInstance instance) : base(instance, "GooglePlayBuyGoodsRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new BuyVirtualGoodResponse (response);
		}
		

		/// <summary>
		/// The ISO 4217 currency code representing the real-world currency used for this transaction.
		/// </summary>
		public GooglePlayBuyGoodsRequest SetCurrencyCode( String currencyCode )
		{
			request.AddString("currencyCode", currencyCode);
			return this;
		}
		/// <summary>
		/// The value obtained from data.getStringExtra("INAPP_DATA_SIGNATURE");
		/// </summary>
		public GooglePlayBuyGoodsRequest SetSignature( String signature )
		{
			request.AddString("signature", signature);
			return this;
		}
		/// <summary>
		/// The value obtained from data.getStringExtra("INAPP_PURCHASE_DATA")
		/// </summary>
		public GooglePlayBuyGoodsRequest SetSignedData( String signedData )
		{
			request.AddString("signedData", signedData);
			return this;
		}
		/// <summary>
		/// The price of this purchase
		/// </summary>
		public GooglePlayBuyGoodsRequest SetSubUnitPrice( double subUnitPrice )
		{
			request.AddNumber("subUnitPrice", subUnitPrice);
			return this;
		}
		/// <summary>
		/// If set to true, the transactionId from this receipt will not be globally valdidated, this will mean replays between players are possible.
		/// It will only validate the transactionId has not been used by this player before.
		/// </summary>
		public GooglePlayBuyGoodsRequest SetUniqueTransactionByPlayer( bool uniqueTransactionByPlayer )
		{
			request.AddBoolean("uniqueTransactionByPlayer", uniqueTransactionByPlayer);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows either a Google Play access code or an access token to be used as an authentication mechanism.}
	/// The access code needs to have at least the https://www.googleapis.com/auth/games scope.}
	/// For more details about Google OAuth 2.0 scopes refer to this: https://developers.google.com/identity/protocols/googlescopes#gamesConfigurationv1configuration}
	/// If the Google Play user is already linked to a player, the current session will switch to the linked player.}
	/// If the current player has previously created an account using either DeviceAuthentictionRequest or RegistrationRequest AND the Google Play user is not already registered with the game, the Google Play user will be linked to the current player.}
	/// If the current player has not authenticated and the Google Play user is not known, a new player will be created using the Google Play details and the session will be authenticated against the new player.}
	/// If the Google Play user is already known, the session will switch to being the previously created user.}
	/// </summary>
	public class GooglePlayConnectRequest : GSTypedRequest<GooglePlayConnectRequest,AuthenticationResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GooglePlayConnectRequest() : base("GooglePlayConnectRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GooglePlayConnectRequest(GSInstance instance) : base(instance, "GooglePlayConnectRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AuthenticationResponse (response);
		}
		

		/// <summary>
		/// The access token is used when using the service id and certificate.
		/// </summary>
		public GooglePlayConnectRequest SetAccessToken( String accessToken )
		{
			request.AddString("accessToken", accessToken);
			return this;
		}
		/// <summary>
		/// The access code is used by the client to make authenticated requests on behalf of the end user. Requires clientId and clientsecret to be set
		/// </summary>
		public GooglePlayConnectRequest SetCode( String code )
		{
			request.AddString("code", code);
			return this;
		}
		/// <summary>
		/// The display of the current player from Google Play. This will be used as the displayName of the gamesparks player if created (or syncDisplayname is true)
		/// </summary>
		public GooglePlayConnectRequest SetDisplayName( String displayName )
		{
			request.AddString("displayName", displayName);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if a new player would have been registered, rather than creating the player.  Defaults to false.
		/// </summary>
		public GooglePlayConnectRequest SetDoNotCreateNewPlayer( bool doNotCreateNewPlayer )
		{
			request.AddBoolean("doNotCreateNewPlayer", doNotCreateNewPlayer);
			return this;
		}
		/// <summary>
		/// Indicates that the server should not try to link the external profile with the current player.  If false, links the external profile to the currently signed in player.  If true, creates a new player and links the external profile to them.  Defaults to false.
		/// </summary>
		public GooglePlayConnectRequest SetDoNotLinkToCurrentPlayer( bool doNotLinkToCurrentPlayer )
		{
			request.AddBoolean("doNotLinkToCurrentPlayer", doNotLinkToCurrentPlayer);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if an account switch would have occurred, rather than switching automatically.  Defaults to false.
		/// </summary>
		public GooglePlayConnectRequest SetErrorOnSwitch( bool errorOnSwitch )
		{
			request.AddBoolean("errorOnSwitch", errorOnSwitch);
			return this;
		}
		/// <summary>
		/// Did you request the plus.login scope when you got the access code or authorisation token from Google? If this is true, we will fetch the user's google+ account and friends
		/// </summary>
		public GooglePlayConnectRequest SetGooglePlusScope( bool googlePlusScope )
		{
			request.AddBoolean("googlePlusScope", googlePlusScope);
			return this;
		}
		/// <summary>
		/// Did you request the profile scope when you got the access code or authorisation token from Google? If this is true, we will fetch the user info by calling https://www.googleapis.com/oauth2/v1/userinfo?alt=json 
		/// </summary>
		public GooglePlayConnectRequest SetProfileScope( bool profileScope )
		{
			request.AddBoolean("profileScope", profileScope);
			return this;
		}
		/// <summary>
		/// Only required when the access code has been granted using an explicit redirectUri, for example when using the mechanism described in https://developers.google.com/+/web/signin/server-side-flow
		/// </summary>
		public GooglePlayConnectRequest SetRedirectUri( String redirectUri )
		{
			request.AddString("redirectUri", redirectUri);
			return this;
		}
		/// <summary>
		/// An optional segment configuration for this request.
		/// If this request creates a new player on the gamesparks platform, the segments of the new player will match the values provided
		/// </summary>
		public GooglePlayConnectRequest SetSegments( GSRequestData segments )
		{
			request.AddObject("segments", segments);
			return this;
		}
		/// <summary>
		/// Indicates that the server should switch to the supplied profile if it isalready associated to a player. Defaults to false.
		/// </summary>
		public GooglePlayConnectRequest SetSwitchIfPossible( bool switchIfPossible )
		{
			request.AddBoolean("switchIfPossible", switchIfPossible);
			return this;
		}
		/// <summary>
		/// Indicates that the associated players displayName should be kept in syn with this profile when it's updated by the external provider.
		/// </summary>
		public GooglePlayConnectRequest SetSyncDisplayName( bool syncDisplayName )
		{
			request.AddBoolean("syncDisplayName", syncDisplayName);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows either a Google Plus access code or an authentication token to be used as an authentication mechanism.}
	/// Once authenticated the platform can determine the current players details from the Google Plus platform and store them within GameSparks.}
	/// GameSparks will determine the player's friends and whether any of them are currently registered with the game.}
	/// If the Google Plus user is already linked to a player, the current session will switch to the linked player.}
	/// If the current player has previously created an account using either DeviceAuthentictionRequest or RegistrationRequest AND the Google Plus user is not already registered with the game, the Google Plus user will be linked to the current player.}
	/// If the current player has not authenticated and the Google Plus user is not known, a new player will be created using the Google Plus details and the session will be authenticated against the new player.}
	/// If the Google Plus user is already known, the session will switch to being the previously created user.}
	/// </summary>
	public class GooglePlusConnectRequest : GSTypedRequest<GooglePlusConnectRequest,AuthenticationResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GooglePlusConnectRequest() : base("GooglePlusConnectRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public GooglePlusConnectRequest(GSInstance instance) : base(instance, "GooglePlusConnectRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AuthenticationResponse (response);
		}
		

		/// <summary>
		/// The access token is used when using the service id and certificate.
		/// </summary>
		public GooglePlusConnectRequest SetAccessToken( String accessToken )
		{
			request.AddString("accessToken", accessToken);
			return this;
		}
		/// <summary>
		/// The access code is used by the client to make authenticated requests on behalf of the end user. Requires clientId and clientsecret to be set
		/// </summary>
		public GooglePlusConnectRequest SetCode( String code )
		{
			request.AddString("code", code);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if a new player would have been registered, rather than creating the player.  Defaults to false.
		/// </summary>
		public GooglePlusConnectRequest SetDoNotCreateNewPlayer( bool doNotCreateNewPlayer )
		{
			request.AddBoolean("doNotCreateNewPlayer", doNotCreateNewPlayer);
			return this;
		}
		/// <summary>
		/// Indicates that the server should not try to link the external profile with the current player.  If false, links the external profile to the currently signed in player.  If true, creates a new player and links the external profile to them.  Defaults to false.
		/// </summary>
		public GooglePlusConnectRequest SetDoNotLinkToCurrentPlayer( bool doNotLinkToCurrentPlayer )
		{
			request.AddBoolean("doNotLinkToCurrentPlayer", doNotLinkToCurrentPlayer);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if an account switch would have occurred, rather than switching automatically.  Defaults to false.
		/// </summary>
		public GooglePlusConnectRequest SetErrorOnSwitch( bool errorOnSwitch )
		{
			request.AddBoolean("errorOnSwitch", errorOnSwitch);
			return this;
		}
		/// <summary>
		/// Only required when the access code has been granted using an explicit redirectUri, for example when using the mechanism described in https://developers.google.com/+/web/signin/server-side-flow
		/// </summary>
		public GooglePlusConnectRequest SetRedirectUri( String redirectUri )
		{
			request.AddString("redirectUri", redirectUri);
			return this;
		}
		/// <summary>
		/// An optional segment configuration for this request.
		/// If this request creates a new player on the gamesparks platform, the segments of the new player will match the values provided
		/// </summary>
		public GooglePlusConnectRequest SetSegments( GSRequestData segments )
		{
			request.AddObject("segments", segments);
			return this;
		}
		/// <summary>
		/// Indicates that the server should switch to the supplied profile if it isalready associated to a player. Defaults to false.
		/// </summary>
		public GooglePlusConnectRequest SetSwitchIfPossible( bool switchIfPossible )
		{
			request.AddBoolean("switchIfPossible", switchIfPossible);
			return this;
		}
		/// <summary>
		/// Indicates that the associated players displayName should be kept in syn with this profile when it's updated by the external provider.
		/// </summary>
		public GooglePlusConnectRequest SetSyncDisplayName( bool syncDisplayName )
		{
			request.AddBoolean("syncDisplayName", syncDisplayName);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Processes a transaction receipt from an App Store in app purchase.}
	/// The GameSparks platform will validate the receipt with Apple and process the response. The transaction_id in the response will be recorded and the request will be rejected if the transaction_id has previously been processed, this prevents replay attacks.}
	/// Once verified, the players account will be credited with the Virtual Good, or Virtual Currency the purchase contains. The virtual good will be looked up by matching the product_id in the response with the 'IOS Product ID' configured against the virtual good.}
	/// </summary>
	public class IOSBuyGoodsRequest : GSTypedRequest<IOSBuyGoodsRequest,BuyVirtualGoodResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public IOSBuyGoodsRequest() : base("IOSBuyGoodsRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public IOSBuyGoodsRequest(GSInstance instance) : base(instance, "IOSBuyGoodsRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new BuyVirtualGoodResponse (response);
		}
		

		/// <summary>
		/// The ISO 4217 currency code representing the real-world currency used for this transaction.
		/// </summary>
		public IOSBuyGoodsRequest SetCurrencyCode( String currencyCode )
		{
			request.AddString("currencyCode", currencyCode);
			return this;
		}
		/// <summary>
		/// The receipt obtained from SKPaymentTransaction. transactionReceipt
		/// </summary>
		public IOSBuyGoodsRequest SetReceipt( String receipt )
		{
			request.AddString("receipt", receipt);
			return this;
		}
		/// <summary>
		/// Should the sandbox account be used
		/// </summary>
		public IOSBuyGoodsRequest SetSandbox( bool sandbox )
		{
			request.AddBoolean("sandbox", sandbox);
			return this;
		}
		/// <summary>
		/// The price of this purchase
		/// </summary>
		public IOSBuyGoodsRequest SetSubUnitPrice( double subUnitPrice )
		{
			request.AddNumber("subUnitPrice", subUnitPrice);
			return this;
		}
		/// <summary>
		/// If set to true, the transactionId from this receipt will not be globally valdidated, this will mean replays between players are possible.
		/// It will only validate the transactionId has not been used by this player before.
		/// </summary>
		public IOSBuyGoodsRequest SetUniqueTransactionByPlayer( bool uniqueTransactionByPlayer )
		{
			request.AddBoolean("uniqueTransactionByPlayer", uniqueTransactionByPlayer);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows a player to join an open challenge.}
	/// </summary>
	public class JoinChallengeRequest : GSTypedRequest<JoinChallengeRequest,JoinChallengeResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public JoinChallengeRequest() : base("JoinChallengeRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public JoinChallengeRequest(GSInstance instance) : base(instance, "JoinChallengeRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new JoinChallengeResponse (response);
		}
		

		/// <summary>
		/// The ID of the challenge
		/// </summary>
		public JoinChallengeRequest SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		/// <summary>
		/// Optional.  Allows the current player's eligibility to be overridden by what is provided here.
		/// </summary>
		public JoinChallengeRequest SetEligibility( GSRequestData eligibility )
		{
			request.AddObject("eligibility", eligibility);
			return this;
		}
		/// <summary>
		/// An optional message to send with the challenge
		/// </summary>
		public JoinChallengeRequest SetMessage( String message )
		{
			request.AddString("message", message);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Requests to join a pending match (found via FindPendingMatchesRequest).}
	/// </summary>
	public class JoinPendingMatchRequest : GSTypedRequest<JoinPendingMatchRequest,JoinPendingMatchResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public JoinPendingMatchRequest() : base("JoinPendingMatchRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public JoinPendingMatchRequest(GSInstance instance) : base(instance, "JoinPendingMatchRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new JoinPendingMatchResponse (response);
		}
		

		/// <summary>
		/// Optional. The matchGroup of the match this player previously registeredfor
		/// </summary>
		public JoinPendingMatchRequest SetMatchGroup( String matchGroup )
		{
			request.AddString("matchGroup", matchGroup);
			return this;
		}
		/// <summary>
		/// The shortCode of the match this player previously registered for
		/// </summary>
		public JoinPendingMatchRequest SetMatchShortCode( String matchShortCode )
		{
			request.AddString("matchShortCode", matchShortCode);
			return this;
		}
		/// <summary>
		/// The pending match ID to join
		/// </summary>
		public JoinPendingMatchRequest SetPendingMatchId( String pendingMatchId )
		{
			request.AddString("pendingMatchId", pendingMatchId);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows a player to join a team or a team to be retrieved.}
	/// </summary>
	public class JoinTeamRequest : GSTypedRequest<JoinTeamRequest,JoinTeamResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public JoinTeamRequest() : base("JoinTeamRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public JoinTeamRequest(GSInstance instance) : base(instance, "JoinTeamRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new JoinTeamResponse (response);
		}
		

		/// <summary>
		/// The team owner to find, used in combination with teamType. If not supplied the current players id will be used
		/// </summary>
		public JoinTeamRequest SetOwnerId( String ownerId )
		{
			request.AddString("ownerId", ownerId);
			return this;
		}
		/// <summary>
		/// The teamId to find (may be null if teamType supplied)
		/// </summary>
		public JoinTeamRequest SetTeamId( String teamId )
		{
			request.AddString("teamId", teamId);
			return this;
		}
		/// <summary>
		/// The teamType to find, used in combination with the current player, or the player defined by ownerId
		/// </summary>
		public JoinTeamRequest SetTeamType( String teamType )
		{
			request.AddString("teamType", teamType);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows a Kongregate account to be used as an authentication mechanism.}
	/// Once authenticated the platform can determine the current players details from the Kongregate platform and store them within GameSparks.}
	/// If the Kongregate user is already linked to a player, the current session will switch to the linked player.}
	/// If the current player has previously created an account using either DeviceAuthentictionRequest or RegistrationRequest AND the Kongregate user is not already registered with the game, the Kongregate user will be linked to the current player.}
	/// If the current player has not authenticated and the Kongregate user is not known, a new player will be created using the Kongregate details and the session will be authenticated against the new player.}
	/// If the Kongregate user is already known, the session will switch to being the previously created user.}
	/// </summary>
	public class KongregateConnectRequest : GSTypedRequest<KongregateConnectRequest,AuthenticationResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public KongregateConnectRequest() : base("KongregateConnectRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public KongregateConnectRequest(GSInstance instance) : base(instance, "KongregateConnectRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AuthenticationResponse (response);
		}
		

		/// <summary>
		/// Indicates whether the server should return an error if a new player would have been registered, rather than creating the player.  Defaults to false.
		/// </summary>
		public KongregateConnectRequest SetDoNotCreateNewPlayer( bool doNotCreateNewPlayer )
		{
			request.AddBoolean("doNotCreateNewPlayer", doNotCreateNewPlayer);
			return this;
		}
		/// <summary>
		/// Indicates that the server should not try to link the external profile with the current player.  If false, links the external profile to the currently signed in player.  If true, creates a new player and links the external profile to them.  Defaults to false.
		/// </summary>
		public KongregateConnectRequest SetDoNotLinkToCurrentPlayer( bool doNotLinkToCurrentPlayer )
		{
			request.AddBoolean("doNotLinkToCurrentPlayer", doNotLinkToCurrentPlayer);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if an account switch would have occurred, rather than switching automatically.  Defaults to false.
		/// </summary>
		public KongregateConnectRequest SetErrorOnSwitch( bool errorOnSwitch )
		{
			request.AddBoolean("errorOnSwitch", errorOnSwitch);
			return this;
		}
		/// <summary>
		/// The gameAuthToken, together with the userID are used by the client to make authenticated requests on behalf of the end user.
		/// </summary>
		public KongregateConnectRequest SetGameAuthToken( String gameAuthToken )
		{
			request.AddString("gameAuthToken", gameAuthToken);
			return this;
		}
		/// <summary>
		/// An optional segment configuration for this request.
		/// If this request creates a new player on the gamesparks platform, the segments of the new player will match the values provided
		/// </summary>
		public KongregateConnectRequest SetSegments( GSRequestData segments )
		{
			request.AddObject("segments", segments);
			return this;
		}
		/// <summary>
		/// Indicates that the server should switch to the supplied profile if it isalready associated to a player. Defaults to false.
		/// </summary>
		public KongregateConnectRequest SetSwitchIfPossible( bool switchIfPossible )
		{
			request.AddBoolean("switchIfPossible", switchIfPossible);
			return this;
		}
		/// <summary>
		/// Indicates that the associated players displayName should be kept in syn with this profile when it's updated by the external provider.
		/// </summary>
		public KongregateConnectRequest SetSyncDisplayName( bool syncDisplayName )
		{
			request.AddBoolean("syncDisplayName", syncDisplayName);
			return this;
		}
		/// <summary>
		/// The userID, together with the gameAuthToken are used by the client to make authenticated requests on behalf of the end user.
		/// </summary>
		public KongregateConnectRequest SetUserId( String userId )
		{
			request.AddString("userId", userId);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Returns the top data for either the specified global leaderboard or the specified challenges leaderboard. The data is sorted as defined in the rules specified in the leaderboard configuration.}
	/// The response contains the top of the leaderboard, and returns the number of entries as defined in the entryCount parameter.}
	/// If a shortCode is supplied, the response will contain the global leaderboard data. If a challengeInstanceId is supplied, the response will contain the leaderboard data for the challenge.}
	/// </summary>
	public class LeaderboardDataRequest : GSTypedRequest<LeaderboardDataRequest,LeaderboardDataResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public LeaderboardDataRequest() : base("LeaderboardDataRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public LeaderboardDataRequest(GSInstance instance) : base(instance, "LeaderboardDataRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LeaderboardDataResponse (response);
		}
		

		/// <summary>
		/// The challenge instance to get the leaderboard data for
		/// </summary>
		public LeaderboardDataRequest SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		/// <summary>
		/// The default behaviour on a social request is to error if the player has no friends (NOTSOCIAL).  Set this flag to suppress that error and return the player's leaderboard entry instead.
		/// </summary>
		public LeaderboardDataRequest SetDontErrorOnNotSocial( bool dontErrorOnNotSocial )
		{
			request.AddBoolean("dontErrorOnNotSocial", dontErrorOnNotSocial);
			return this;
		}
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public LeaderboardDataRequest SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public LeaderboardDataRequest SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public LeaderboardDataRequest SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public LeaderboardDataRequest SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		/// <summary>
		/// Returns the leaderboard excluding the player's social friends
		/// </summary>
		public LeaderboardDataRequest SetInverseSocial( bool inverseSocial )
		{
			request.AddBoolean("inverseSocial", inverseSocial);
			return this;
		}
		/// <summary>
		/// The short code of the leaderboard
		/// </summary>
		public LeaderboardDataRequest SetLeaderboardShortCode( String leaderboardShortCode )
		{
			request.AddString("leaderboardShortCode", leaderboardShortCode);
			return this;
		}
		/// <summary>
		/// The offset into the set of leaderboards returned
		/// </summary>
		public LeaderboardDataRequest SetOffset( long offset )
		{
			request.AddNumber("offset", offset);
			return this;
		}
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public LeaderboardDataRequest SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public LeaderboardDataRequest SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public LeaderboardDataRequest SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Get the leaderboard entry data for the current player or a given player.}
	/// For each leaderboard it returns the array of leaderboard entries that the player has.}
	/// </summary>
	public class LeaderboardsEntriesRequest : GSTypedRequest<LeaderboardsEntriesRequest,LeaderboardsEntriesResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public LeaderboardsEntriesRequest() : base("LeaderboardsEntriesRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public LeaderboardsEntriesRequest(GSInstance instance) : base(instance, "LeaderboardsEntriesRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LeaderboardsEntriesResponse (response);
		}
		

		/// <summary>
		/// The challenge leaderboards to return entries for
		/// </summary>
		public LeaderboardsEntriesRequest SetChallenges( List<string> challenges )
		{
			request.AddStringList("challenges", challenges);
			return this;
		}
		/// <summary>
		/// Returns the leaderboard excluding the player's social friends
		/// </summary>
		public LeaderboardsEntriesRequest SetInverseSocial( bool inverseSocial )
		{
			request.AddBoolean("inverseSocial", inverseSocial);
			return this;
		}
		/// <summary>
		/// The list of leaderboards shortcodes
		/// </summary>
		public LeaderboardsEntriesRequest SetLeaderboards( List<string> leaderboards )
		{
			request.AddStringList("leaderboards", leaderboards);
			return this;
		}
		/// <summary>
		/// The player id. Leave out to use the current player id
		/// </summary>
		public LeaderboardsEntriesRequest SetPlayer( String player )
		{
			request.AddString("player", player);
			return this;
		}
		/// <summary>
		/// Set to true to include the player's game friends
		/// </summary>
		public LeaderboardsEntriesRequest SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The types of team to apply this request to
		/// </summary>
		public LeaderboardsEntriesRequest SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows a player to leave a team.}
	/// </summary>
	public class LeaveTeamRequest : GSTypedRequest<LeaveTeamRequest,LeaveTeamResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public LeaveTeamRequest() : base("LeaveTeamRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public LeaveTeamRequest(GSInstance instance) : base(instance, "LeaveTeamRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LeaveTeamResponse (response);
		}
		

		/// <summary>
		/// The team owner to find, used in combination with teamType. If not supplied the current players id will be used
		/// </summary>
		public LeaveTeamRequest SetOwnerId( String ownerId )
		{
			request.AddString("ownerId", ownerId);
			return this;
		}
		/// <summary>
		/// The teamId to find (may be null if teamType supplied)
		/// </summary>
		public LeaveTeamRequest SetTeamId( String teamId )
		{
			request.AddString("teamId", teamId);
			return this;
		}
		/// <summary>
		/// The teamType to find, used in combination with the current player, or the player defined by ownerId
		/// </summary>
		public LeaveTeamRequest SetTeamType( String teamType )
		{
			request.AddString("teamType", teamType);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Retrieves a list of the configured achievements in the game, along with whether the current player has earned the achievement.}
	/// </summary>
	public class ListAchievementsRequest : GSTypedRequest<ListAchievementsRequest,ListAchievementsResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListAchievementsRequest() : base("ListAchievementsRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListAchievementsRequest(GSInstance instance) : base(instance, "ListAchievementsRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new ListAchievementsResponse (response);
		}
		

				
	}
	
	
	/// <summary>
	/// Lists existing bulk jobs.}
	/// </summary>
	public class ListBulkJobsAdminRequest : GSTypedRequest<ListBulkJobsAdminRequest,ListBulkJobsAdminResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListBulkJobsAdminRequest() : base("ListBulkJobsAdminRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListBulkJobsAdminRequest(GSInstance instance) : base(instance, "ListBulkJobsAdminRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new ListBulkJobsAdminResponse (response);
		}
		

		/// <summary>
		/// The IDs of existing bulk jobs to get details for
		/// </summary>
		public ListBulkJobsAdminRequest SetBulkJobIds( List<string> bulkJobIds )
		{
			request.AddStringList("bulkJobIds", bulkJobIds);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Returns a list of challenges in the state defined in the 'state' field.}
	/// The response can be further filtered by passing a shortCode field which will limit the returned lists to challenges of that short code.}
	/// Valid states are:}
	/// WAITING : The challenge has been issued and accepted and is waiting for the start date.}
	/// RUNNING : The challenge is active.}
	/// ISSUED : The challenge has been issued by the current player and is waiting to be accepted.}
	/// RECEIVED : The challenge has been issued to the current player and is waiting to be accepted.}
	/// COMPLETE : The challenge has completed.}
	/// DECLINED : The challenge has been issued by the current player and has been declined.}
	/// </summary>
	public class ListChallengeRequest : GSTypedRequest<ListChallengeRequest,ListChallengeResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListChallengeRequest() : base("ListChallengeRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListChallengeRequest(GSInstance instance) : base(instance, "ListChallengeRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new ListChallengeResponse (response);
		}
		

		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public ListChallengeRequest SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// The offset (page number) to start from (default=0)
		/// </summary>
		public ListChallengeRequest SetOffset( long offset )
		{
			request.AddNumber("offset", offset);
			return this;
		}
		/// <summary>
		/// The type of challenge to return
		/// </summary>
		public ListChallengeRequest SetShortCode( String shortCode )
		{
			request.AddString("shortCode", shortCode);
			return this;
		}
		/// <summary>
		/// The state of the challenged to be returned
		/// </summary>
		public ListChallengeRequest SetState( String state )
		{
			request.AddString("state", state);
			return this;
		}
		/// <summary>
		/// The states of the challenges to be returned
		/// </summary>
		public ListChallengeRequest SetStates( List<string> states )
		{
			request.AddStringList("states", states);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Returns the list of configured challenge types.}
	/// </summary>
	public class ListChallengeTypeRequest : GSTypedRequest<ListChallengeTypeRequest,ListChallengeTypeResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListChallengeTypeRequest() : base("ListChallengeTypeRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListChallengeTypeRequest(GSInstance instance) : base(instance, "ListChallengeTypeRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new ListChallengeTypeResponse (response);
		}
		

				
	}
	
	
	/// <summary>
	/// Returns the list of the current players game friends.}
	/// A Game friend is someone in their social network who also plays the game.}
	/// Against each friend, an indicator is supplied to show whether the friend is currently connected to the GameSparks service}
	/// </summary>
	public class ListGameFriendsRequest : GSTypedRequest<ListGameFriendsRequest,ListGameFriendsResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListGameFriendsRequest() : base("ListGameFriendsRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListGameFriendsRequest(GSInstance instance) : base(instance, "ListGameFriendsRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new ListGameFriendsResponse (response);
		}
		

				
	}
	
	
	/// <summary>
	/// Returns the list of the current players friends in their social network, who are not yet playing this game.}
	/// This is dependent on the security and privacy policies of the social network.}
	/// For example, Facebook's policies prevent this friend list being provided, whereas Twitter will supply a list of users who are not playing the game.}
	/// </summary>
	public class ListInviteFriendsRequest : GSTypedRequest<ListInviteFriendsRequest,ListInviteFriendsResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListInviteFriendsRequest() : base("ListInviteFriendsRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListInviteFriendsRequest(GSInstance instance) : base(instance, "ListInviteFriendsRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new ListInviteFriendsResponse (response);
		}
		

				
	}
	
	
	/// <summary>
	/// Returns a list of all leaderboards configured in the game.}
	/// </summary>
	public class ListLeaderboardsRequest : GSTypedRequest<ListLeaderboardsRequest,ListLeaderboardsResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListLeaderboardsRequest() : base("ListLeaderboardsRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListLeaderboardsRequest(GSInstance instance) : base(instance, "ListLeaderboardsRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new ListLeaderboardsResponse (response);
		}
		

				
	}
	
	
	/// <summary>
	/// Returns the list of the current player's messages / notifications.}
	/// The list only contains un-dismissed messages, to dismiss a message see DismissMessageRequest Read the section on Messages to see the complete list of messages and their meaning.}
	/// </summary>
	public class ListMessageDetailRequest : GSTypedRequest<ListMessageDetailRequest,ListMessageDetailResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListMessageDetailRequest() : base("ListMessageDetailRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListMessageDetailRequest(GSInstance instance) : base(instance, "ListMessageDetailRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new ListMessageDetailResponse (response);
		}
		

		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public ListMessageDetailRequest SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// An optional filter that limits the message types returned
		/// </summary>
		public ListMessageDetailRequest SetInclude( String include )
		{
			request.AddString("include", include);
			return this;
		}
		/// <summary>
		/// The offset (page number) to start from (default=0)
		/// </summary>
		public ListMessageDetailRequest SetOffset( long offset )
		{
			request.AddNumber("offset", offset);
			return this;
		}
		/// <summary>
		/// The status of messages to be retrieved. If omitted, messages of all statuses will be retrieved
		/// </summary>
		public ListMessageDetailRequest SetStatus( String status )
		{
			request.AddString("status", status);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Returns the list of the current player's messages / notifications.}
	/// The list only contains un-dismissed messages, to dismiss a message see DismissMessageRequest Read the section on Messages to see the complete list of messages and their meaning.}
	/// </summary>
	public class ListMessageRequest : GSTypedRequest<ListMessageRequest,ListMessageResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListMessageRequest() : base("ListMessageRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListMessageRequest(GSInstance instance) : base(instance, "ListMessageRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new ListMessageResponse (response);
		}
		

		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public ListMessageRequest SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// An optional filter that limits the message types returned
		/// </summary>
		public ListMessageRequest SetInclude( String include )
		{
			request.AddString("include", include);
			return this;
		}
		/// <summary>
		/// The offset (page number) to start from (default=0)
		/// </summary>
		public ListMessageRequest SetOffset( long offset )
		{
			request.AddNumber("offset", offset);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Returns a summary of the list of the current players messages / notifications.}
	/// The list only contains un-dismissed messages, to dismiss a message see DismissMessageRequest.}
	/// The full message can be retrieved using GetMessageRequest Read the section on Messages to see the complete list of messages and their meanings.}
	/// </summary>
	public class ListMessageSummaryRequest : GSTypedRequest<ListMessageSummaryRequest,ListMessageSummaryResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListMessageSummaryRequest() : base("ListMessageSummaryRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListMessageSummaryRequest(GSInstance instance) : base(instance, "ListMessageSummaryRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new ListMessageSummaryResponse (response);
		}
		

		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public ListMessageSummaryRequest SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// The offset (page number) to start from (default=0)
		/// </summary>
		public ListMessageSummaryRequest SetOffset( long offset )
		{
			request.AddNumber("offset", offset);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Get a list of the messages sent to the team (by players using SendTeamChatMessageRequest).}
	/// </summary>
	public class ListTeamChatRequest : GSTypedRequest<ListTeamChatRequest,ListTeamChatResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListTeamChatRequest() : base("ListTeamChatRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListTeamChatRequest(GSInstance instance) : base(instance, "ListTeamChatRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new ListTeamChatResponse (response);
		}
		

		/// <summary>
		/// The number of messages to return (default=50)
		/// </summary>
		public ListTeamChatRequest SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// The offset (nth message) to start from (default=0)
		/// </summary>
		public ListTeamChatRequest SetOffset( long offset )
		{
			request.AddNumber("offset", offset);
			return this;
		}
		/// <summary>
		/// The team owner to find, used in combination with teamType. If not supplied the current players id will be used
		/// </summary>
		public ListTeamChatRequest SetOwnerId( String ownerId )
		{
			request.AddString("ownerId", ownerId);
			return this;
		}
		/// <summary>
		/// The teamId to find (may be null if teamType supplied)
		/// </summary>
		public ListTeamChatRequest SetTeamId( String teamId )
		{
			request.AddString("teamId", teamId);
			return this;
		}
		/// <summary>
		/// The teamType to find, used in combination with the current player, or the player defined by ownerId
		/// </summary>
		public ListTeamChatRequest SetTeamType( String teamType )
		{
			request.AddString("teamType", teamType);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Returns a list of teams. Can be filtered on team name or team type.}
	/// </summary>
	public class ListTeamsRequest : GSTypedRequest<ListTeamsRequest,ListTeamsResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListTeamsRequest() : base("ListTeamsRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListTeamsRequest(GSInstance instance) : base(instance, "ListTeamsRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new ListTeamsResponse (response);
		}
		

		/// <summary>
		/// The number of teams to return in a page (default=50)
		/// </summary>
		public ListTeamsRequest SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// The offset (page number) to start from (default=0)
		/// </summary>
		public ListTeamsRequest SetOffset( long offset )
		{
			request.AddNumber("offset", offset);
			return this;
		}
		/// <summary>
		/// An optional filter to return teams with a matching name
		/// </summary>
		public ListTeamsRequest SetTeamNameFilter( String teamNameFilter )
		{
			request.AddString("teamNameFilter", teamNameFilter);
			return this;
		}
		/// <summary>
		/// An optional filter to return teams of a particular type
		/// </summary>
		public ListTeamsRequest SetTeamTypeFilter( String teamTypeFilter )
		{
			request.AddString("teamTypeFilter", teamTypeFilter);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Returns a list of the current player's transaction history.}
	/// </summary>
	public class ListTransactionsRequest : GSTypedRequest<ListTransactionsRequest,ListTransactionsResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListTransactionsRequest() : base("ListTransactionsRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListTransactionsRequest(GSInstance instance) : base(instance, "ListTransactionsRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new ListTransactionsResponse (response);
		}
		

		/// <summary>
		/// Optional date constraint to list transactions from
		/// </summary>
		public ListTransactionsRequest SetDateFrom( DateTime dateFrom )
		{
			request.AddDate("dateFrom", dateFrom);
			return this;
		}
		/// <summary>
		/// Optional date constraint to list transactions to
		/// </summary>
		public ListTransactionsRequest SetDateTo( DateTime dateTo )
		{
			request.AddDate("dateTo", dateTo);
			return this;
		}
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public ListTransactionsRequest SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// An optional filter that limits the transaction types returned
		/// </summary>
		public ListTransactionsRequest SetInclude( String include )
		{
			request.AddString("include", include);
			return this;
		}
		/// <summary>
		/// The offset (page number) to start from (default=0)
		/// </summary>
		public ListTransactionsRequest SetOffset( long offset )
		{
			request.AddNumber("offset", offset);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Returns the list of configured virtual goods.}
	/// </summary>
	public class ListVirtualGoodsRequest : GSTypedRequest<ListVirtualGoodsRequest,ListVirtualGoodsResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListVirtualGoodsRequest() : base("ListVirtualGoodsRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ListVirtualGoodsRequest(GSInstance instance) : base(instance, "ListVirtualGoodsRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new ListVirtualGoodsResponse (response);
		}
		

		/// <summary>
		/// If true, the returned list will include disabled VirtualVoods
		/// </summary>
		public ListVirtualGoodsRequest SetIncludeDisabled( bool includeDisabled )
		{
			request.AddBoolean("includeDisabled", includeDisabled);
			return this;
		}
		/// <summary>
		/// A filter to only include goods with the given tags. Each good must have all the provided tags.
		/// </summary>
		public ListVirtualGoodsRequest SetTags( List<string> tags )
		{
			request.AddStringList("tags", tags);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows a user defined event to be triggered. The event will be posted to the challenge specified.}
	/// This call differs from most as it does not have a fixed format. The @class, challengeInstanceId and eventKey attributes are common, but the rest of the attributes are as defined in the Event object configured in the dev portal.}
	/// The example below shows a request to en event with a short code of HS with 2 attributes, 'HS' & 'GL'.}
	/// </summary>
	public class LogChallengeEventRequest : GSTypedRequest<LogChallengeEventRequest,LogChallengeEventResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public LogChallengeEventRequest() : base("LogChallengeEventRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public LogChallengeEventRequest(GSInstance instance) : base(instance, "LogChallengeEventRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		public LogChallengeEventRequest SetEventAttribute(String key, long value){
			request.AddNumber (key, value);
			return this;
		}
		
		public LogChallengeEventRequest SetEventAttribute(String key, int value){
			request.AddNumber (key, value);
			return this;
		}

		public LogChallengeEventRequest SetEventAttribute(String key, String value){
			request.AddString (key, value);
			return this;
		}

		public LogChallengeEventRequest SetEventAttribute(String key, GSRequestData value){
			request.AddObject (key, value);
			return this;
		}
		
		public LogChallengeEventRequest SetEventAttribute(String key, List<GSData> value){
			request.AddObjectList (key, value);
			return this;
		}
		
		public LogChallengeEventRequest SetEventAttribute(String key, List<string> value){
			request.AddStringList (key, value);
			return this;
		}
		
		public LogChallengeEventRequest SetEventAttribute(String key, List<long> value){
			request.AddNumberList (key, value);
			return this;
		}
		
		public LogChallengeEventRequest SetEventAttribute(String key, List<int> value){
			request.AddNumberList (key, value);
			return this;
		}

		/// <summary>
		/// The ID challenge instance to target
		/// </summary>
		public LogChallengeEventRequest SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		/// <summary>
		/// The short code of the event to trigger
		/// </summary>
		public LogChallengeEventRequest SetEventKey( String eventKey )
		{
			request.AddString("eventKey", eventKey);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows a user defined event to be triggered.}
	/// This call differs from most as it does not have a fixed format. The @class and eventKey attributes are common, but the rest of the attributes are as defined in the Event object configured in the dev portal.}
	/// The example below shows a request to an event with a short code of HS with 2 attributes, 'HS' & 'GL'.}
	/// </summary>
	public class LogEventRequest : GSTypedRequest<LogEventRequest,LogEventResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public LogEventRequest() : base("LogEventRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public LogEventRequest(GSInstance instance) : base(instance, "LogEventRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest SetEventAttribute(String key, long value){
			request.AddNumber (key, value);
			return this;
		}
		
		public LogEventRequest SetEventAttribute(String key, int value){
			request.AddNumber (key, value);
			return this;
		}

		public LogEventRequest SetEventAttribute(String key, String value){
			request.AddString (key, value);
			return this;
		}

		public LogEventRequest SetEventAttribute(String key, GSRequestData value){
			request.AddObject (key, value);
			return this;
		}
		
		public LogEventRequest SetEventAttribute(String key, List<GSData> value){
			request.AddObjectList (key, value);
			return this;
		}
		
		public LogEventRequest SetEventAttribute(String key, List<string> value){
			request.AddStringList (key, value);
			return this;
		}
		
		public LogEventRequest SetEventAttribute(String key, List<long> value){
			request.AddNumberList (key, value);
			return this;
		}
		
		public LogEventRequest SetEventAttribute(String key, List<int> value){
			request.AddNumberList (key, value);
			return this;
		}

		/// <summary>
		/// The short code of the event to trigger
		/// </summary>
		public LogEventRequest SetEventKey( String eventKey )
		{
			request.AddString("eventKey", eventKey);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Find the details of an existing match this player belongs to, using the matchId}
	/// </summary>
	public class MatchDetailsRequest : GSTypedRequest<MatchDetailsRequest,MatchDetailsResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public MatchDetailsRequest() : base("MatchDetailsRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public MatchDetailsRequest(GSInstance instance) : base(instance, "MatchDetailsRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new MatchDetailsResponse (response);
		}
		

		/// <summary>
		/// The matchId to find the details of
		/// </summary>
		public MatchDetailsRequest SetMatchId( String matchId )
		{
			request.AddString("matchId", matchId);
			return this;
		}
		/// <summary>
		/// Adds realtime server details if the match has been created using Cloud Code and it has not been realtime enabled
		/// </summary>
		public MatchDetailsRequest SetRealtimeEnabled( bool realtimeEnabled )
		{
			request.AddBoolean("realtimeEnabled", realtimeEnabled);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Register this player for matchmaking, using the given skill and matchShortCode.}
	/// Players looking for a match using the same matchShortCode will be considered for a match, based on the matchConfig.}
	/// Each player must match the other for the match to be found.}
	/// If the matchShortCode points to a match with realtime enabled, in order to minimise latency, the location of Players and their proximity to one another takes precedence over their reciprocal skill values.}
	/// </summary>
	public class MatchmakingRequest : GSTypedRequest<MatchmakingRequest,MatchmakingResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public MatchmakingRequest() : base("MatchmakingRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public MatchmakingRequest(GSInstance instance) : base(instance, "MatchmakingRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new MatchmakingResponse (response);
		}
		

		/// <summary>
		/// The action to take on the already in-flight request for this match. Currently supported actions are: 'cancel'
		/// </summary>
		public MatchmakingRequest SetAction( String action )
		{
			request.AddString("action", action);
			return this;
		}
		/// <summary>
		/// The query that will be applied to the PendingMatch collection
		/// </summary>
		public MatchmakingRequest SetCustomQuery( GSRequestData customQuery )
		{
			request.AddObject("customQuery", customQuery);
			return this;
		}
		/// <summary>
		/// A JSON Map of any data that will be associated to the pending match
		/// </summary>
		public MatchmakingRequest SetMatchData( GSRequestData matchData )
		{
			request.AddObject("matchData", matchData);
			return this;
		}
		/// <summary>
		/// Optional. Players will be grouped based on the distinct value passed in here, only players in the same group can be matched together
		/// </summary>
		public MatchmakingRequest SetMatchGroup( String matchGroup )
		{
			request.AddString("matchGroup", matchGroup);
			return this;
		}
		/// <summary>
		/// The shortCode of the match type this player is registering for
		/// </summary>
		public MatchmakingRequest SetMatchShortCode( String matchShortCode )
		{
			request.AddString("matchShortCode", matchShortCode);
			return this;
		}
		/// <summary>
		/// A JSON Map of any data that will be associated to this user in a pending match
		/// </summary>
		public MatchmakingRequest SetParticipantData( GSRequestData participantData )
		{
			request.AddObject("participantData", participantData);
			return this;
		}
		/// <summary>
		/// The skill of the player looking for a match
		/// </summary>
		public MatchmakingRequest SetSkill( long skill )
		{
			request.AddNumber("skill", skill);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows an Nintendo Network Service Account (NSA) to be used as an authentication mechanism.}
	/// Once authenticated the platform can determine the current players details from the NSA and store them within GameSparks.}
	/// GameSparks will determine the player's friends and whether any of them are currently registered with the game.}
	/// If the NSA is already linked to a player, the current session will switch to the linked player.}
	/// If the current player has previously created an account using either DeviceAuthentictionRequest or RegistrationRequest AND the NSA is not already registered with the game, the NSA will be linked to the current player.}
	/// If the current player has not authenticated and the NSA is not known, a new player will be created using the NSA details and the session will be authenticated against the new player.}
	/// If the NSA is already known, the session will switch to being the previously created user.}
	/// </summary>
	public class NXConnectRequest : GSTypedRequest<NXConnectRequest,AuthenticationResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public NXConnectRequest() : base("NXConnectRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public NXConnectRequest(GSInstance instance) : base(instance, "NXConnectRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AuthenticationResponse (response);
		}
		

		/// <summary>
		/// Whether to create one GameSparks player per console login ID
		/// </summary>
		public NXConnectRequest SetAccountPerLoginId( bool accountPerLoginId )
		{
			request.AddBoolean("accountPerLoginId", accountPerLoginId);
			return this;
		}
		/// <summary>
		/// The display name of the current player from NX. This will be used as the displayName of the gamesparks player if created (or syncDisplayname is true)
		/// </summary>
		public NXConnectRequest SetDisplayName( String displayName )
		{
			request.AddString("displayName", displayName);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if a new player would have been registered, rather than creating the player.  Defaults to false.
		/// </summary>
		public NXConnectRequest SetDoNotCreateNewPlayer( bool doNotCreateNewPlayer )
		{
			request.AddBoolean("doNotCreateNewPlayer", doNotCreateNewPlayer);
			return this;
		}
		/// <summary>
		/// Indicates that the server should not try to link the external profile with the current player.  If false, links the external profile to the currently signed in player.  If true, creates a new player and links the external profile to them.  Defaults to false.
		/// </summary>
		public NXConnectRequest SetDoNotLinkToCurrentPlayer( bool doNotLinkToCurrentPlayer )
		{
			request.AddBoolean("doNotLinkToCurrentPlayer", doNotLinkToCurrentPlayer);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if an account switch would have occurred, rather than switching automatically.  Defaults to false.
		/// </summary>
		public NXConnectRequest SetErrorOnSwitch( bool errorOnSwitch )
		{
			request.AddBoolean("errorOnSwitch", errorOnSwitch);
			return this;
		}
		/// <summary>
		/// The NSA ID token obtained from Nintendo
		/// </summary>
		public NXConnectRequest SetNsaIdToken( String nsaIdToken )
		{
			request.AddString("nsaIdToken", nsaIdToken);
			return this;
		}
		/// <summary>
		/// An optional segment configuration for this request.
		/// If this request creates a new player on the gamesparks platform, the segments of the new player will match the values provided
		/// </summary>
		public NXConnectRequest SetSegments( GSRequestData segments )
		{
			request.AddObject("segments", segments);
			return this;
		}
		/// <summary>
		/// Indicates that the server should switch to the supplied profile if it isalready associated to a player. Defaults to false.
		/// </summary>
		public NXConnectRequest SetSwitchIfPossible( bool switchIfPossible )
		{
			request.AddBoolean("switchIfPossible", switchIfPossible);
			return this;
		}
		/// <summary>
		/// Indicates that the associated players displayName should be kept in syn with this profile when it's updated by the external provider.
		/// </summary>
		public NXConnectRequest SetSyncDisplayName( bool syncDisplayName )
		{
			request.AddBoolean("syncDisplayName", syncDisplayName);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows a PSN account to be used as an authentication mechanism.}
	/// Once authenticated the platform can determine the current players details from the PSN platform and store them within GameSparks.}
	/// GameSparks will determine the player's friends and whether any of them are currently registered with the game.}
	/// If the PSN user is already linked to a player, the current session will switch to the linked player.}
	/// If the current player has previously created an account using either DeviceAuthentictionRequest or RegistrationRequest AND the PSN user is not already registered with the game, the PSN user will be linked to the current player.}
	/// If the current player has not authenticated and the PSN user is not known, a new player will be created using the PSN details and the session will be authenticated against the new player.}
	/// If the PSN user is already known, the session will switch to being the previously created user.}
	/// </summary>
	public class PSNAccountConnectRequest : GSTypedRequest<PSNAccountConnectRequest,AuthenticationResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public PSNAccountConnectRequest() : base("PSNAccountConnectRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public PSNAccountConnectRequest(GSInstance instance) : base(instance, "PSNAccountConnectRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AuthenticationResponse (response);
		}
		

		/// <summary>
		/// The authorization code obtained from PSN, as described here https://ps4.scedev.net/resources/documents/SDK/latest/NpAuth-Reference/0008.html
		/// </summary>
		public PSNAccountConnectRequest SetAuthorizationCode( String authorizationCode )
		{
			request.AddString("authorizationCode", authorizationCode);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if a new player would have been registered, rather than creating the player.  Defaults to false.
		/// </summary>
		public PSNAccountConnectRequest SetDoNotCreateNewPlayer( bool doNotCreateNewPlayer )
		{
			request.AddBoolean("doNotCreateNewPlayer", doNotCreateNewPlayer);
			return this;
		}
		/// <summary>
		/// Indicates that the server should not try to link the external profile with the current player.  If false, links the external profile to the currently signed in player.  If true, creates a new player and links the external profile to them.  Defaults to false.
		/// </summary>
		public PSNAccountConnectRequest SetDoNotLinkToCurrentPlayer( bool doNotLinkToCurrentPlayer )
		{
			request.AddBoolean("doNotLinkToCurrentPlayer", doNotLinkToCurrentPlayer);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if an account switch would have occurred, rather than switching automatically.  Defaults to false.
		/// </summary>
		public PSNAccountConnectRequest SetErrorOnSwitch( bool errorOnSwitch )
		{
			request.AddBoolean("errorOnSwitch", errorOnSwitch);
			return this;
		}
		/// <summary>
		/// When using the authorization code obtained from PlayStation®4/PlayStation®Vita/PlayStation®3, this is not required.
		/// When using the authorization code obtained with the PC authentication gateway, set the URI issued from the Developer Network website.
		/// </summary>
		public PSNAccountConnectRequest SetRedirectUri( String redirectUri )
		{
			request.AddString("redirectUri", redirectUri);
			return this;
		}
		/// <summary>
		/// An optional segment configuration for this request.
		/// If this request creates a new player on the gamesparks platform, the segments of the new player will match the values provided
		/// </summary>
		public PSNAccountConnectRequest SetSegments( GSRequestData segments )
		{
			request.AddObject("segments", segments);
			return this;
		}
		/// <summary>
		/// Indicates that the server should switch to the supplied profile if it isalready associated to a player. Defaults to false.
		/// </summary>
		public PSNAccountConnectRequest SetSwitchIfPossible( bool switchIfPossible )
		{
			request.AddBoolean("switchIfPossible", switchIfPossible);
			return this;
		}
		/// <summary>
		/// Indicates that the associated players displayName should be kept in syn with this profile when it's updated by the external provider.
		/// </summary>
		public PSNAccountConnectRequest SetSyncDisplayName( bool syncDisplayName )
		{
			request.AddBoolean("syncDisplayName", syncDisplayName);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// DEPRECATED - Use PSNAccountConnectRequest instead.}
	/// Allows a PSN account to be used as an authentication mechanism.}
	/// Once authenticated the platform can determine the current players details from the PSN platform and store them within GameSparks.}
	/// GameSparks will determine the player's friends and whether any of them are currently registered with the game.}
	/// If the PSN user is already linked to a player, the current session will switch to the linked player.}
	/// If the current player has previously created an account using either DeviceAuthentictionRequest or RegistrationRequest AND the PSN user is not already registered with the game, the PSN user will be linked to the current player.}
	/// If the current player has not authenticated and the PSN user is not known, a new player will be created using the PSN details and the session will be authenticated against the new player.}
	/// If the PSN user is already known, the session will switch to being the previously created user.}
	/// </summary>
	public class PSNConnectRequest : GSTypedRequest<PSNConnectRequest,AuthenticationResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public PSNConnectRequest() : base("PSNConnectRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public PSNConnectRequest(GSInstance instance) : base(instance, "PSNConnectRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AuthenticationResponse (response);
		}
		

		/// <summary>
		/// The authorization code obtained from PSN, as described here https://ps4.scedev.net/resources/documents/SDK/latest/NpAuth-Reference/0008.html
		/// </summary>
		public PSNConnectRequest SetAuthorizationCode( String authorizationCode )
		{
			request.AddString("authorizationCode", authorizationCode);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if a new player would have been registered, rather than creating the player.  Defaults to false.
		/// </summary>
		public PSNConnectRequest SetDoNotCreateNewPlayer( bool doNotCreateNewPlayer )
		{
			request.AddBoolean("doNotCreateNewPlayer", doNotCreateNewPlayer);
			return this;
		}
		/// <summary>
		/// Indicates that the server should not try to link the external profile with the current player.  If false, links the external profile to the currently signed in player.  If true, creates a new player and links the external profile to them.  Defaults to false.
		/// </summary>
		public PSNConnectRequest SetDoNotLinkToCurrentPlayer( bool doNotLinkToCurrentPlayer )
		{
			request.AddBoolean("doNotLinkToCurrentPlayer", doNotLinkToCurrentPlayer);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if an account switch would have occurred, rather than switching automatically.  Defaults to false.
		/// </summary>
		public PSNConnectRequest SetErrorOnSwitch( bool errorOnSwitch )
		{
			request.AddBoolean("errorOnSwitch", errorOnSwitch);
			return this;
		}
		/// <summary>
		/// When using the authorization code obtained from PlayStation®4/PlayStation®Vita/PlayStation®3, this is not required.
		/// When using the authorization code obtained with the PC authentication gateway, set the URI issued from the Developer Network website.
		/// </summary>
		public PSNConnectRequest SetRedirectUri( String redirectUri )
		{
			request.AddString("redirectUri", redirectUri);
			return this;
		}
		/// <summary>
		/// An optional segment configuration for this request.
		/// If this request creates a new player on the gamesparks platform, the segments of the new player will match the values provided
		/// </summary>
		public PSNConnectRequest SetSegments( GSRequestData segments )
		{
			request.AddObject("segments", segments);
			return this;
		}
		/// <summary>
		/// Indicates that the server should switch to the supplied profile if it isalready associated to a player. Defaults to false.
		/// </summary>
		public PSNConnectRequest SetSwitchIfPossible( bool switchIfPossible )
		{
			request.AddBoolean("switchIfPossible", switchIfPossible);
			return this;
		}
		/// <summary>
		/// Indicates that the associated players displayName should be kept in syn with this profile when it's updated by the external provider.
		/// </summary>
		public PSNConnectRequest SetSyncDisplayName( bool syncDisplayName )
		{
			request.AddBoolean("syncDisplayName", syncDisplayName);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Processes an update of entitlement in PlayStation network.}
	/// The GameSparks platform will update the 'use_count' for an entitlement (by default 'use_count' is 1).}
	/// The request will be rejected if entitlement 'use_limit' is 0}
	/// GampSparks platform by default will use internally saved PSN user access token}
	/// </summary>
	public class PsnBuyGoodsRequest : GSTypedRequest<PsnBuyGoodsRequest,BuyVirtualGoodResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public PsnBuyGoodsRequest() : base("PsnBuyGoodsRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public PsnBuyGoodsRequest(GSInstance instance) : base(instance, "PsnBuyGoodsRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new BuyVirtualGoodResponse (response);
		}
		

		/// <summary>
		/// The authorization code obtained from PSN, as described here https://ps4.scedev.net/resources/documents/SDK/latest/NpAuth-Reference/0008.html
		/// </summary>
		public PsnBuyGoodsRequest SetAuthorizationCode( String authorizationCode )
		{
			request.AddString("authorizationCode", authorizationCode);
			return this;
		}
		/// <summary>
		/// The ISO 4217 currency code representing the real-world currency used for this transaction.
		/// </summary>
		public PsnBuyGoodsRequest SetCurrencyCode( String currencyCode )
		{
			request.AddString("currencyCode", currencyCode);
			return this;
		}
		/// <summary>
		/// Specify the entitlement label of the entitlement to update. (Not an entitlement ID).
		/// </summary>
		public PsnBuyGoodsRequest SetEntitlementLabel( String entitlementLabel )
		{
			request.AddString("entitlementLabel", entitlementLabel);
			return this;
		}
		/// <summary>
		/// When using the authorization code obtained from PlayStation®4/PlayStation®Vita/PlayStation®3, this is not required.
		/// When using the authorization code obtained with the PC authentication gateway, set the URI issued from the Developer Network website.
		/// </summary>
		public PsnBuyGoodsRequest SetRedirectUri( String redirectUri )
		{
			request.AddString("redirectUri", redirectUri);
			return this;
		}
		/// <summary>
		/// The price of this purchase
		/// </summary>
		public PsnBuyGoodsRequest SetSubUnitPrice( double subUnitPrice )
		{
			request.AddNumber("subUnitPrice", subUnitPrice);
			return this;
		}
		/// <summary>
		/// If set to true, the transactionId from this receipt will not be globally valdidated, this will mean replays between players are possible.
		/// It will only validate the transactionId has not been used by this player before.
		/// </summary>
		public PsnBuyGoodsRequest SetUniqueTransactionByPlayer( bool uniqueTransactionByPlayer )
		{
			request.AddBoolean("uniqueTransactionByPlayer", uniqueTransactionByPlayer);
			return this;
		}
		/// <summary>
		/// Optional - specify the quantity of the entitlement to use. Default = 1
		/// </summary>
		public PsnBuyGoodsRequest SetUseCount( long useCount )
		{
			request.AddNumber("useCount", useCount);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Registers the current device for push notifications. Currently GameSparks supports iOS, Android (GCM), FCM, Kindle, Viber & Microsoft Push notifications.}
	/// Supply the device type, and the push notification identifier for the device.}
	/// </summary>
	public class PushRegistrationRequest : GSTypedRequest<PushRegistrationRequest,PushRegistrationResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public PushRegistrationRequest() : base("PushRegistrationRequest"){
			request.AddString("deviceOS", GS.GSPlatform.DeviceOS);
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public PushRegistrationRequest(GSInstance instance) : base(instance, "PushRegistrationRequest"){
			request.AddString("deviceOS", instance.GSPlatform.DeviceOS);
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new PushRegistrationResponse (response);
		}
		

		/// <summary>
		/// The type of id, valid values are ios, android, fcm, wp8, w8, kindle or viber
		/// </summary>
		public PushRegistrationRequest SetDeviceOS( String deviceOS )
		{
			request.AddString("deviceOS", deviceOS);
			return this;
		}
		/// <summary>
		/// The push notification identifier for the device
		/// </summary>
		public PushRegistrationRequest SetPushId( String pushId )
		{
			request.AddString("pushId", pushId);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows a QQ access token to be used as an authentication mechanism.}
	/// Once authenticated the platform can determine the current players details from the QQ platform and store them within GameSparks.}
	/// If the QQ user is already linked to a player, the current session will switch to the linked player.}
	/// If the current player has previously created an account using either DeviceAuthenticationRequest or RegistrationRequest AND the QQ user is not already registered with the game, the QQ user will be linked to the current player.}
	/// If the current player has not authenticated and the QQ user is not known, a new player will be created using the QQ details and the session will be authenticated against the new player.}
	/// If the QQ user is already known, the session will switch to being the previously created user.}
	/// </summary>
	public class QQConnectRequest : GSTypedRequest<QQConnectRequest,AuthenticationResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public QQConnectRequest() : base("QQConnectRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public QQConnectRequest(GSInstance instance) : base(instance, "QQConnectRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AuthenticationResponse (response);
		}
		

		/// <summary>
		/// The access token is used by the client to make authenticated requests on behalf of the end user.
		/// When the access token expires, attempts to use it will fail, and a new access token must be obtained using the refresh token.
		/// </summary>
		public QQConnectRequest SetAccessToken( String accessToken )
		{
			request.AddString("accessToken", accessToken);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if a new player would have been registered, rather than creating the player.  Defaults to false.
		/// </summary>
		public QQConnectRequest SetDoNotCreateNewPlayer( bool doNotCreateNewPlayer )
		{
			request.AddBoolean("doNotCreateNewPlayer", doNotCreateNewPlayer);
			return this;
		}
		/// <summary>
		/// Indicates that the server should not try to link the external profile with the current player.  If false, links the external profile to the currently signed in player.  If true, creates a new player and links the external profile to them.  Defaults to false.
		/// </summary>
		public QQConnectRequest SetDoNotLinkToCurrentPlayer( bool doNotLinkToCurrentPlayer )
		{
			request.AddBoolean("doNotLinkToCurrentPlayer", doNotLinkToCurrentPlayer);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if an account switch would have occurred, rather than switching automatically.  Defaults to false.
		/// </summary>
		public QQConnectRequest SetErrorOnSwitch( bool errorOnSwitch )
		{
			request.AddBoolean("errorOnSwitch", errorOnSwitch);
			return this;
		}
		/// <summary>
		/// An optional segment configuration for this request.
		/// If this request creates a new player on the gamesparks platform, the segments of the new player will match the values provided
		/// </summary>
		public QQConnectRequest SetSegments( GSRequestData segments )
		{
			request.AddObject("segments", segments);
			return this;
		}
		/// <summary>
		/// Indicates that the server should switch to the supplied profile if it isalready associated to a player. Defaults to false.
		/// </summary>
		public QQConnectRequest SetSwitchIfPossible( bool switchIfPossible )
		{
			request.AddBoolean("switchIfPossible", switchIfPossible);
			return this;
		}
		/// <summary>
		/// Indicates that the associated players displayName should be kept in syn with this profile when it's updated by the external provider.
		/// </summary>
		public QQConnectRequest SetSyncDisplayName( bool syncDisplayName )
		{
			request.AddBoolean("syncDisplayName", syncDisplayName);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows a new player to be created using a username, password display name.}
	/// </summary>
	public class RegistrationRequest : GSTypedRequest<RegistrationRequest,RegistrationResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public RegistrationRequest() : base("RegistrationRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public RegistrationRequest(GSInstance instance) : base(instance, "RegistrationRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new RegistrationResponse (response);
		}
		

		/// <summary>
		/// A display name to use
		/// </summary>
		public RegistrationRequest SetDisplayName( String displayName )
		{
			request.AddString("displayName", displayName);
			return this;
		}
		/// <summary>
		/// The previously registered password
		/// </summary>
		public RegistrationRequest SetPassword( String password )
		{
			request.AddString("password", password);
			return this;
		}
		/// <summary>
		/// An optional segment configuration for this request.
		/// If this request creates a new player on the gamesparks platform, the segments of the new player will match the values provided
		/// </summary>
		public RegistrationRequest SetSegments( GSRequestData segments )
		{
			request.AddObject("segments", segments);
			return this;
		}
		/// <summary>
		/// The previously registered player name
		/// </summary>
		public RegistrationRequest SetUserName( String userName )
		{
			request.AddString("userName", userName);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Revokes the purchase of a good. The items aquired will be removed from remaining items of the player.}
	/// </summary>
	public class RevokePurchaseGoodsRequest : GSTypedRequest<RevokePurchaseGoodsRequest,RevokePurchaseGoodsResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public RevokePurchaseGoodsRequest() : base("RevokePurchaseGoodsRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public RevokePurchaseGoodsRequest(GSInstance instance) : base(instance, "RevokePurchaseGoodsRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new RevokePurchaseGoodsResponse (response);
		}
		

		/// <summary>
		/// The playerId for which to revoke the transaction
		/// </summary>
		public RevokePurchaseGoodsRequest SetPlayerId( String playerId )
		{
			request.AddString("playerId", playerId);
			return this;
		}
		/// <summary>
		/// The store type for which to revoke these transactions
		/// </summary>
		public RevokePurchaseGoodsRequest SetStoreType( String storeType )
		{
			request.AddString("storeType", storeType);
			return this;
		}
		/// <summary>
		/// The list of transactionIds to revoke
		/// </summary>
		public RevokePurchaseGoodsRequest SetTransactionIds( List<string> transactionIds )
		{
			request.AddStringList("transactionIds", transactionIds);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Schedules a bulk job to be run against multiple players.}
	/// </summary>
	public class ScheduleBulkJobAdminRequest : GSTypedRequest<ScheduleBulkJobAdminRequest,ScheduleBulkJobAdminResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ScheduleBulkJobAdminRequest() : base("ScheduleBulkJobAdminRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ScheduleBulkJobAdminRequest(GSInstance instance) : base(instance, "ScheduleBulkJobAdminRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new ScheduleBulkJobAdminResponse (response);
		}
		

		/// <summary>
		/// Optional data to be passed into the script
		/// </summary>
		public ScheduleBulkJobAdminRequest SetData( GSRequestData data )
		{
			request.AddObject("data", data);
			return this;
		}
		/// <summary>
		/// The short code of the cloud code module to be executed against each player
		/// </summary>
		public ScheduleBulkJobAdminRequest SetModuleShortCode( String moduleShortCode )
		{
			request.AddString("moduleShortCode", moduleShortCode);
			return this;
		}
		/// <summary>
		/// The query to be run against the player collection to identify which players to execute the cloud code for
		/// </summary>
		public ScheduleBulkJobAdminRequest SetPlayerQuery( GSRequestData playerQuery )
		{
			request.AddObject("playerQuery", playerQuery);
			return this;
		}
		/// <summary>
		/// An optional date and time for this job to be run
		/// </summary>
		public ScheduleBulkJobAdminRequest SetScheduledTime( DateTime scheduledTime )
		{
			request.AddDate("scheduledTime", scheduledTime);
			return this;
		}
		/// <summary>
		/// The script to be executed against each player
		/// </summary>
		public ScheduleBulkJobAdminRequest SetScript( String script )
		{
			request.AddString("script", script);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Sends a message to one or more game friend(s). A game friend is someone in the players social network who also plays the game.}
	/// </summary>
	public class SendFriendMessageRequest : GSTypedRequest<SendFriendMessageRequest,SendFriendMessageResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public SendFriendMessageRequest() : base("SendFriendMessageRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public SendFriendMessageRequest(GSInstance instance) : base(instance, "SendFriendMessageRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new SendFriendMessageResponse (response);
		}
		

		/// <summary>
		/// One or more friend ID's. This can be supplied as a single string, or a JSON array
		/// </summary>
		public SendFriendMessageRequest SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// The message to send
		/// </summary>
		public SendFriendMessageRequest SetMessage( String message )
		{
			request.AddString("message", message);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Send a message to all the players who are member of the given team}
	/// </summary>
	public class SendTeamChatMessageRequest : GSTypedRequest<SendTeamChatMessageRequest,SendTeamChatMessageResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public SendTeamChatMessageRequest() : base("SendTeamChatMessageRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public SendTeamChatMessageRequest(GSInstance instance) : base(instance, "SendTeamChatMessageRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new SendTeamChatMessageResponse (response);
		}
		

		/// <summary>
		/// The message to send
		/// </summary>
		public SendTeamChatMessageRequest SetMessage( String message )
		{
			request.AddString("message", message);
			return this;
		}
		/// <summary>
		/// The team owner to find, used in combination with teamType. If not supplied the current players id will be used
		/// </summary>
		public SendTeamChatMessageRequest SetOwnerId( String ownerId )
		{
			request.AddString("ownerId", ownerId);
			return this;
		}
		/// <summary>
		/// The teamId to find (may be null if teamType supplied)
		/// </summary>
		public SendTeamChatMessageRequest SetTeamId( String teamId )
		{
			request.AddString("teamId", teamId);
			return this;
		}
		/// <summary>
		/// The teamType to find, used in combination with the current player, or the player defined by ownerId
		/// </summary>
		public SendTeamChatMessageRequest SetTeamType( String teamType )
		{
			request.AddString("teamType", teamType);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows a player's internal profile to be disconnected from an external system to which it is linked.  Any friends linked as result of this connection will be removed.}
	/// </summary>
	public class SocialDisconnectRequest : GSTypedRequest<SocialDisconnectRequest,SocialDisconnectResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public SocialDisconnectRequest() : base("SocialDisconnectRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public SocialDisconnectRequest(GSInstance instance) : base(instance, "SocialDisconnectRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new SocialDisconnectResponse (response);
		}
		

		/// <summary>
		/// The external system from which to disconnect this profile, supplied as a two letter ID. The options are: {FACEBOOK:FB, AMAZON:AM, GAME_CENTER:GC
		/// GOOGLE_PLAY:GY , GOOGLE_PLUS:GP, KONGREGATE:KO, PSN:PS, QQ:QQ, STEAM:ST, TWITCH:TC, TWITTER:TW, VIBER:VB, WECHAT:WC, XBOX:XB
		/// XBOXONE:X1, NINTENDO:NX}
		/// </summary>
		public SocialDisconnectRequest SetSystemId( String systemId )
		{
			request.AddString("systemId", systemId);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Returns leaderboard data that only contains entries of players that are game friends with the current player.}
	/// The GameSparks platform will attempt to return players both ahead and behind the current player, where data is available.}
	/// The entry count defines how many player should be returned both ahead and behind. The numer of results may vary if there are not enough friends either ahead or behind.}
	/// </summary>
	public class SocialLeaderboardDataRequest : GSTypedRequest<SocialLeaderboardDataRequest,LeaderboardDataResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public SocialLeaderboardDataRequest() : base("SocialLeaderboardDataRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public SocialLeaderboardDataRequest(GSInstance instance) : base(instance, "SocialLeaderboardDataRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LeaderboardDataResponse (response);
		}
		

		/// <summary>
		/// The challenge instance to get the leaderboard data for
		/// </summary>
		public SocialLeaderboardDataRequest SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		/// <summary>
		/// The default behaviour on a social request is to error if the player has no friends (NOTSOCIAL).  Set this flag to suppress that error and return the player's leaderboard entry instead.
		/// </summary>
		public SocialLeaderboardDataRequest SetDontErrorOnNotSocial( bool dontErrorOnNotSocial )
		{
			request.AddBoolean("dontErrorOnNotSocial", dontErrorOnNotSocial);
			return this;
		}
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public SocialLeaderboardDataRequest SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public SocialLeaderboardDataRequest SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public SocialLeaderboardDataRequest SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public SocialLeaderboardDataRequest SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		/// <summary>
		/// Returns the leaderboard excluding the player's social friends
		/// </summary>
		public SocialLeaderboardDataRequest SetInverseSocial( bool inverseSocial )
		{
			request.AddBoolean("inverseSocial", inverseSocial);
			return this;
		}
		/// <summary>
		/// The short code of the leaderboard
		/// </summary>
		public SocialLeaderboardDataRequest SetLeaderboardShortCode( String leaderboardShortCode )
		{
			request.AddString("leaderboardShortCode", leaderboardShortCode);
			return this;
		}
		/// <summary>
		/// The offset into the set of leaderboards returned
		/// </summary>
		public SocialLeaderboardDataRequest SetOffset( long offset )
		{
			request.AddNumber("offset", offset);
			return this;
		}
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public SocialLeaderboardDataRequest SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public SocialLeaderboardDataRequest SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public SocialLeaderboardDataRequest SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Returns detials of the current social connections of this player. Each connection .}
	/// </summary>
	public class SocialStatusRequest : GSTypedRequest<SocialStatusRequest,SocialStatusResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public SocialStatusRequest() : base("SocialStatusRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public SocialStatusRequest(GSInstance instance) : base(instance, "SocialStatusRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new SocialStatusResponse (response);
		}
		

				
	}
	
	
	/// <summary>
	/// Processes a 'orderid' from a Steam.}
	/// The GameSparks platform will validate the 'orderid' with Steam and process the response. The 'orderid' from the response will be recorded and the request will be rejected, if the 'orderid' has previously been processed, this prevents replay attacks.}
	/// Once verified, the players account will be credited with the Virtual Good, or Virtual Currency the purchase contains. The virtual good will be looked up by matching the 'itemid' in the response with the 'Steam Product ID' configured against the virtual good.}
	/// </summary>
	public class SteamBuyGoodsRequest : GSTypedRequest<SteamBuyGoodsRequest,BuyVirtualGoodResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public SteamBuyGoodsRequest() : base("SteamBuyGoodsRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public SteamBuyGoodsRequest(GSInstance instance) : base(instance, "SteamBuyGoodsRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new BuyVirtualGoodResponse (response);
		}
		

		/// <summary>
		/// The ISO 4217 currency code representing the real-world currency used for this transaction.
		/// </summary>
		public SteamBuyGoodsRequest SetCurrencyCode( String currencyCode )
		{
			request.AddString("currencyCode", currencyCode);
			return this;
		}
		/// <summary>
		/// Unique 64-bit ID for order
		/// </summary>
		public SteamBuyGoodsRequest SetOrderId( String orderId )
		{
			request.AddString("orderId", orderId);
			return this;
		}
		/// <summary>
		/// The price of this purchase
		/// </summary>
		public SteamBuyGoodsRequest SetSubUnitPrice( double subUnitPrice )
		{
			request.AddNumber("subUnitPrice", subUnitPrice);
			return this;
		}
		/// <summary>
		/// If set to true, the transactionId from this receipt will not be globally valdidated, this will mean replays between players are possible.
		/// It will only validate the transactionId has not been used by this player before.
		/// </summary>
		public SteamBuyGoodsRequest SetUniqueTransactionByPlayer( bool uniqueTransactionByPlayer )
		{
			request.AddBoolean("uniqueTransactionByPlayer", uniqueTransactionByPlayer);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows a Steam sessionTicket to be used as an authentication mechanism.}
	/// Once authenticated the platform can determine the current players details from the Steam platform and store them within GameSparks.}
	/// GameSparks will determine the player's friends and whether any of them are currently registered with the game.}
	/// If the Steam user is already linked to a player, the current session will switch to the linked player.}
	/// If the current player has previously created an account using either DeviceAuthentictionRequest or RegistrationRequest AND the Steam user is not already registered with the game, the Steam user will be linked to the current player.}
	/// If the current player has not authenticated and the Steam user is not known, a new player will be created using the Steam details and the session will be authenticated against the new player.}
	/// If the Steam user is already known, the session will switch to being the previously created user.}
	/// </summary>
	public class SteamConnectRequest : GSTypedRequest<SteamConnectRequest,AuthenticationResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public SteamConnectRequest() : base("SteamConnectRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public SteamConnectRequest(GSInstance instance) : base(instance, "SteamConnectRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AuthenticationResponse (response);
		}
		

		/// <summary>
		/// Indicates whether the server should return an error if a new player would have been registered, rather than creating the player.  Defaults to false.
		/// </summary>
		public SteamConnectRequest SetDoNotCreateNewPlayer( bool doNotCreateNewPlayer )
		{
			request.AddBoolean("doNotCreateNewPlayer", doNotCreateNewPlayer);
			return this;
		}
		/// <summary>
		/// Indicates that the server should not try to link the external profile with the current player.  If false, links the external profile to the currently signed in player.  If true, creates a new player and links the external profile to them.  Defaults to false.
		/// </summary>
		public SteamConnectRequest SetDoNotLinkToCurrentPlayer( bool doNotLinkToCurrentPlayer )
		{
			request.AddBoolean("doNotLinkToCurrentPlayer", doNotLinkToCurrentPlayer);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if an account switch would have occurred, rather than switching automatically.  Defaults to false.
		/// </summary>
		public SteamConnectRequest SetErrorOnSwitch( bool errorOnSwitch )
		{
			request.AddBoolean("errorOnSwitch", errorOnSwitch);
			return this;
		}
		/// <summary>
		/// An optional segment configuration for this request.
		/// If this request creates a new player on the gamesparks platform, the segments of the new player will match the values provided
		/// </summary>
		public SteamConnectRequest SetSegments( GSRequestData segments )
		{
			request.AddObject("segments", segments);
			return this;
		}
		/// <summary>
		/// The hex encoded UTF-8 string representation of the ticket acquired calling the Steam SDKs GetAuthSessionTicket.
		/// </summary>
		public SteamConnectRequest SetSessionTicket( String sessionTicket )
		{
			request.AddString("sessionTicket", sessionTicket);
			return this;
		}
		/// <summary>
		/// Indicates that the server should switch to the supplied profile if it isalready associated to a player. Defaults to false.
		/// </summary>
		public SteamConnectRequest SetSwitchIfPossible( bool switchIfPossible )
		{
			request.AddBoolean("switchIfPossible", switchIfPossible);
			return this;
		}
		/// <summary>
		/// Indicates that the associated players displayName should be kept in syn with this profile when it's updated by the external provider.
		/// </summary>
		public SteamConnectRequest SetSyncDisplayName( bool syncDisplayName )
		{
			request.AddBoolean("syncDisplayName", syncDisplayName);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows a Twitch account to be used as an authentication mechanism.}
	/// Once authenticated the platform can determine the current players details from the Twitch platform and store them within GameSparks.}
	/// If the Twitch user is already linked to a player, the current session will switch to the linked player.}
	/// If the current player has previously created an account using either DeviceAuthentictionRequest or RegistrationRequest AND the Twitch user is not already registered with the game, the Twitch user will be linked to the current player.}
	/// If the current player has not authenticated and the Twitch user is not known, a new player will be created using the Twitch details and the session will be authenticated against the new player.}
	/// If the Twitch user is already known, the session will switch to being the previously created user.}
	/// </summary>
	public class TwitchConnectRequest : GSTypedRequest<TwitchConnectRequest,AuthenticationResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public TwitchConnectRequest() : base("TwitchConnectRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public TwitchConnectRequest(GSInstance instance) : base(instance, "TwitchConnectRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AuthenticationResponse (response);
		}
		

		/// <summary>
		/// The access token is used by the client to make authenticated requests on behalf of the end user.
		/// </summary>
		public TwitchConnectRequest SetAccessToken( String accessToken )
		{
			request.AddString("accessToken", accessToken);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if a new player would have been registered, rather than creating the player.  Defaults to false.
		/// </summary>
		public TwitchConnectRequest SetDoNotCreateNewPlayer( bool doNotCreateNewPlayer )
		{
			request.AddBoolean("doNotCreateNewPlayer", doNotCreateNewPlayer);
			return this;
		}
		/// <summary>
		/// Indicates that the server should not try to link the external profile with the current player.  If false, links the external profile to the currently signed in player.  If true, creates a new player and links the external profile to them.  Defaults to false.
		/// </summary>
		public TwitchConnectRequest SetDoNotLinkToCurrentPlayer( bool doNotLinkToCurrentPlayer )
		{
			request.AddBoolean("doNotLinkToCurrentPlayer", doNotLinkToCurrentPlayer);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if an account switch would have occurred, rather than switching automatically.  Defaults to false.
		/// </summary>
		public TwitchConnectRequest SetErrorOnSwitch( bool errorOnSwitch )
		{
			request.AddBoolean("errorOnSwitch", errorOnSwitch);
			return this;
		}
		/// <summary>
		/// An optional segment configuration for this request.
		/// If this request creates a new player on the gamesparks platform, the segments of the new player will match the values provided
		/// </summary>
		public TwitchConnectRequest SetSegments( GSRequestData segments )
		{
			request.AddObject("segments", segments);
			return this;
		}
		/// <summary>
		/// Indicates that the server should switch to the supplied profile if it isalready associated to a player. Defaults to false.
		/// </summary>
		public TwitchConnectRequest SetSwitchIfPossible( bool switchIfPossible )
		{
			request.AddBoolean("switchIfPossible", switchIfPossible);
			return this;
		}
		/// <summary>
		/// Indicates that the associated players displayName should be kept in syn with this profile when it's updated by the external provider.
		/// </summary>
		public TwitchConnectRequest SetSyncDisplayName( bool syncDisplayName )
		{
			request.AddBoolean("syncDisplayName", syncDisplayName);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows a Twitter account to be used as an authentication mechanism.}
	/// Once authenticated the platform can determine the current players details from the Twitter platform and store them within GameSparks.}
	/// GameSparks will determine the player's friends and whether any of them are currently registered with the game.}
	/// If the Twitter user is already linked to a player, the current session will switch to the linked player.}
	/// If the current player has previously created an account using either DeviceAuthentictionRequest or RegistrationRequest AND the Twitter user is not already registered with the game, the Twitter user will be linked to the current player.}
	/// If the current player has not authenticated and the Twitter user is not known, a new player will be created using the Twitter details and the session will be authenticated against the new player.}
	/// If the Twitter user is already known, the session will switch to being the previously created user.}
	/// </summary>
	public class TwitterConnectRequest : GSTypedRequest<TwitterConnectRequest,AuthenticationResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public TwitterConnectRequest() : base("TwitterConnectRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public TwitterConnectRequest(GSInstance instance) : base(instance, "TwitterConnectRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AuthenticationResponse (response);
		}
		

		/// <summary>
		/// The accessSecret is obtained at the same time as the accessToken, and is required to sign requests to Twitter's services that require the accessToken.
		/// </summary>
		public TwitterConnectRequest SetAccessSecret( String accessSecret )
		{
			request.AddString("accessSecret", accessSecret);
			return this;
		}
		/// <summary>
		/// The accessToken represents a player's permission to share access to their account with your application.
		/// To obtain an accessToken for the player see https://dev.twitter.com/docs/auth/obtaining-access-tokens.
		/// Currently, Twitter accessTokens do not expire but they can be revoked by the player.
		/// </summary>
		public TwitterConnectRequest SetAccessToken( String accessToken )
		{
			request.AddString("accessToken", accessToken);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if a new player would have been registered, rather than creating the player.  Defaults to false.
		/// </summary>
		public TwitterConnectRequest SetDoNotCreateNewPlayer( bool doNotCreateNewPlayer )
		{
			request.AddBoolean("doNotCreateNewPlayer", doNotCreateNewPlayer);
			return this;
		}
		/// <summary>
		/// Indicates that the server should not try to link the external profile with the current player.  If false, links the external profile to the currently signed in player.  If true, creates a new player and links the external profile to them.  Defaults to false.
		/// </summary>
		public TwitterConnectRequest SetDoNotLinkToCurrentPlayer( bool doNotLinkToCurrentPlayer )
		{
			request.AddBoolean("doNotLinkToCurrentPlayer", doNotLinkToCurrentPlayer);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if an account switch would have occurred, rather than switching automatically.  Defaults to false.
		/// </summary>
		public TwitterConnectRequest SetErrorOnSwitch( bool errorOnSwitch )
		{
			request.AddBoolean("errorOnSwitch", errorOnSwitch);
			return this;
		}
		/// <summary>
		/// An optional segment configuration for this request.
		/// If this request creates a new player on the gamesparks platform, the segments of the new player will match the values provided
		/// </summary>
		public TwitterConnectRequest SetSegments( GSRequestData segments )
		{
			request.AddObject("segments", segments);
			return this;
		}
		/// <summary>
		/// Indicates that the server should switch to the supplied profile if it isalready associated to a player. Defaults to false.
		/// </summary>
		public TwitterConnectRequest SetSwitchIfPossible( bool switchIfPossible )
		{
			request.AddBoolean("switchIfPossible", switchIfPossible);
			return this;
		}
		/// <summary>
		/// Indicates that the associated players displayName should be kept in syn with this profile when it's updated by the external provider.
		/// </summary>
		public TwitterConnectRequest SetSyncDisplayName( bool syncDisplayName )
		{
			request.AddBoolean("syncDisplayName", syncDisplayName);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows a message status to be updated.}
	/// </summary>
	public class UpdateMessageRequest : GSTypedRequest<UpdateMessageRequest,UpdateMessageResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public UpdateMessageRequest() : base("UpdateMessageRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public UpdateMessageRequest(GSInstance instance) : base(instance, "UpdateMessageRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new UpdateMessageResponse (response);
		}
		

		/// <summary>
		/// The messageId of the message to update
		/// </summary>
		public UpdateMessageRequest SetMessageId( String messageId )
		{
			request.AddString("messageId", messageId);
			return this;
		}
		/// <summary>
		/// The status to set on the message
		/// </summary>
		public UpdateMessageRequest SetStatus( String status )
		{
			request.AddString("status", status);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows a Viber account to be used as an authentication mechanism.}
	/// Once authenticated the platform can determine the current players details from the Viber platform and store them within GameSparks.}
	/// A successful authentication will also register the player to receive Viber push notifications.}
	/// GameSparks will determine the player's friends and whether any of them are currently registered with the game.}
	/// If the Viber user is already linked to a player, the current session will switch to the linked player.}
	/// If the current player has previously created an account using either DeviceAuthentictionRequest or RegistrationRequest AND the Viber user is not already registered with the game, the Viber user will be linked to the current player.}
	/// If the current player has not authenticated and the Viber user is not known, a new player will be created using the Viber details and the session will be authenticated against the new player.}
	/// If the Viber user is already known, the session will switch to being the previously created user.}
	/// </summary>
	public class ViberConnectRequest : GSTypedRequest<ViberConnectRequest,AuthenticationResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ViberConnectRequest() : base("ViberConnectRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public ViberConnectRequest(GSInstance instance) : base(instance, "ViberConnectRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AuthenticationResponse (response);
		}
		

		/// <summary>
		/// The accessToken represents a player's permission to share access to their account with your application.
		/// </summary>
		public ViberConnectRequest SetAccessToken( String accessToken )
		{
			request.AddString("accessToken", accessToken);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if a new player would have been registered, rather than creating the player.  Defaults to false.
		/// </summary>
		public ViberConnectRequest SetDoNotCreateNewPlayer( bool doNotCreateNewPlayer )
		{
			request.AddBoolean("doNotCreateNewPlayer", doNotCreateNewPlayer);
			return this;
		}
		/// <summary>
		/// Indicates that the server should not try to link the external profile with the current player.  If false, links the external profile to the currently signed in player.  If true, creates a new player and links the external profile to them.  Defaults to false.
		/// </summary>
		public ViberConnectRequest SetDoNotLinkToCurrentPlayer( bool doNotLinkToCurrentPlayer )
		{
			request.AddBoolean("doNotLinkToCurrentPlayer", doNotLinkToCurrentPlayer);
			return this;
		}
		/// <summary>
		/// Does not automatocally register this user for push notifications. Defaults to false.
		/// </summary>
		public ViberConnectRequest SetDoNotRegisterForPush( bool doNotRegisterForPush )
		{
			request.AddBoolean("doNotRegisterForPush", doNotRegisterForPush);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if an account switch would have occurred, rather than switching automatically.  Defaults to false.
		/// </summary>
		public ViberConnectRequest SetErrorOnSwitch( bool errorOnSwitch )
		{
			request.AddBoolean("errorOnSwitch", errorOnSwitch);
			return this;
		}
		/// <summary>
		/// An optional segment configuration for this request.
		/// If this request creates a new player on the gamesparks platform, the segments of the new player will match the values provided
		/// </summary>
		public ViberConnectRequest SetSegments( GSRequestData segments )
		{
			request.AddObject("segments", segments);
			return this;
		}
		/// <summary>
		/// Indicates that the server should switch to the supplied profile if it isalready associated to a player. Defaults to false.
		/// </summary>
		public ViberConnectRequest SetSwitchIfPossible( bool switchIfPossible )
		{
			request.AddBoolean("switchIfPossible", switchIfPossible);
			return this;
		}
		/// <summary>
		/// Indicates that the associated players displayName should be kept in syn with this profile when it's updated by the external provider.
		/// </summary>
		public ViberConnectRequest SetSyncDisplayName( bool syncDisplayName )
		{
			request.AddBoolean("syncDisplayName", syncDisplayName);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows a WeChat access token to be used as an authentication mechanism.}
	/// Once authenticated the platform can determine the current players details from the WeChat platform and store them within GameSparks.}
	/// If the WeChat user is already linked to a player, the current session will switch to the linked player.}
	/// If the current player has previously created an account using either DeviceAuthenticationRequest or RegistrationRequest AND the WeChat user is not already registered with the game, the WeChat user will be linked to the current player.}
	/// If the current player has not authenticated and the WeChat user is not known, a new player will be created using the WeChat details and the session will be authenticated against the new player.}
	/// If the WeChat user is already known, the session will switch to being the previously created user.}
	/// </summary>
	public class WeChatConnectRequest : GSTypedRequest<WeChatConnectRequest,AuthenticationResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public WeChatConnectRequest() : base("WeChatConnectRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public WeChatConnectRequest(GSInstance instance) : base(instance, "WeChatConnectRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AuthenticationResponse (response);
		}
		

		/// <summary>
		/// The access token sould be obtained from WeChat
		/// It is used by the client to make authenticated requests on behalf of the end user.
		/// </summary>
		public WeChatConnectRequest SetAccessToken( String accessToken )
		{
			request.AddString("accessToken", accessToken);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if a new player would have been registered, rather than creating the player.  Defaults to false.
		/// </summary>
		public WeChatConnectRequest SetDoNotCreateNewPlayer( bool doNotCreateNewPlayer )
		{
			request.AddBoolean("doNotCreateNewPlayer", doNotCreateNewPlayer);
			return this;
		}
		/// <summary>
		/// Indicates that the server should not try to link the external profile with the current player.  If false, links the external profile to the currently signed in player.  If true, creates a new player and links the external profile to them.  Defaults to false.
		/// </summary>
		public WeChatConnectRequest SetDoNotLinkToCurrentPlayer( bool doNotLinkToCurrentPlayer )
		{
			request.AddBoolean("doNotLinkToCurrentPlayer", doNotLinkToCurrentPlayer);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if an account switch would have occurred, rather than switching automatically.  Defaults to false.
		/// </summary>
		public WeChatConnectRequest SetErrorOnSwitch( bool errorOnSwitch )
		{
			request.AddBoolean("errorOnSwitch", errorOnSwitch);
			return this;
		}
		/// <summary>
		/// The open ID corresponding to the WeChat user
		/// </summary>
		public WeChatConnectRequest SetOpenId( String openId )
		{
			request.AddString("openId", openId);
			return this;
		}
		/// <summary>
		/// An optional segment configuration for this request.
		/// If this request creates a new player on the gamesparks platform, the segments of the new player will match the values provided
		/// </summary>
		public WeChatConnectRequest SetSegments( GSRequestData segments )
		{
			request.AddObject("segments", segments);
			return this;
		}
		/// <summary>
		/// Indicates that the server should switch to the supplied profile if it isalready associated to a player. Defaults to false.
		/// </summary>
		public WeChatConnectRequest SetSwitchIfPossible( bool switchIfPossible )
		{
			request.AddBoolean("switchIfPossible", switchIfPossible);
			return this;
		}
		/// <summary>
		/// Indicates that the associated players displayName should be kept in syn with this profile when it's updated by the external provider.
		/// </summary>
		public WeChatConnectRequest SetSyncDisplayName( bool syncDisplayName )
		{
			request.AddBoolean("syncDisplayName", syncDisplayName);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Processes a transaction receipt from a windows store purchase.}
	/// The GameSparks platform will validate the receipt using the signature embedded in the xml. The Id in the xml will be recorded and the request will be rejected if the Id has previously been processed, this prevents replay attacks.}
	/// Once verified, the players account will be credited with the Virtual Good, or Virtual Currency the purchase contains. The virtual good will be looked up by matching the productId in the xml with the 'WP8 Product ID' configured against the virtual good.}
	/// </summary>
	public class WindowsBuyGoodsRequest : GSTypedRequest<WindowsBuyGoodsRequest,BuyVirtualGoodResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public WindowsBuyGoodsRequest() : base("WindowsBuyGoodsRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public WindowsBuyGoodsRequest(GSInstance instance) : base(instance, "WindowsBuyGoodsRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new BuyVirtualGoodResponse (response);
		}
		

		/// <summary>
		/// The ISO 4217 currency code representing the real-world currency used for this transaction.
		/// </summary>
		public WindowsBuyGoodsRequest SetCurrencyCode( String currencyCode )
		{
			request.AddString("currencyCode", currencyCode);
			return this;
		}
		/// <summary>
		/// Allows you to specify the platform
		/// </summary>
		public WindowsBuyGoodsRequest SetPlatform( String platform )
		{
			request.AddString("platform", platform);
			return this;
		}
		/// <summary>
		/// The xml reciept returned from the windows phone 8 store
		/// </summary>
		public WindowsBuyGoodsRequest SetReceipt( String receipt )
		{
			request.AddString("receipt", receipt);
			return this;
		}
		/// <summary>
		/// The price of this purchase
		/// </summary>
		public WindowsBuyGoodsRequest SetSubUnitPrice( double subUnitPrice )
		{
			request.AddNumber("subUnitPrice", subUnitPrice);
			return this;
		}
		/// <summary>
		/// If set to true, the transactionId from this receipt will not be globally valdidated, this will mean replays between players are possible.
		/// It will only validate the transactionId has not been used by this player before.
		/// </summary>
		public WindowsBuyGoodsRequest SetUniqueTransactionByPlayer( bool uniqueTransactionByPlayer )
		{
			request.AddBoolean("uniqueTransactionByPlayer", uniqueTransactionByPlayer);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Withdraws a challenge previously issued by the current player.}
	/// This can only be done while the challenge is in the ISSUED state. Once it's been accepted the challenge can not be withdrawn.}
	/// </summary>
	public class WithdrawChallengeRequest : GSTypedRequest<WithdrawChallengeRequest,WithdrawChallengeResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public WithdrawChallengeRequest() : base("WithdrawChallengeRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public WithdrawChallengeRequest(GSInstance instance) : base(instance, "WithdrawChallengeRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new WithdrawChallengeResponse (response);
		}
		

		/// <summary>
		/// The ID of the challenge
		/// </summary>
		public WithdrawChallengeRequest SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		/// <summary>
		/// An optional message to send with the challenge
		/// </summary>
		public WithdrawChallengeRequest SetMessage( String message )
		{
			request.AddString("message", message);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows an Xbox Live Shared Token String to be used as an authentication mechanism.}
	/// Once authenticated the platform can determine the current players details from the Xbox Live and store them within GameSparks.}
	/// GameSparks will determine the player's friends and whether any of them are currently registered with the game.}
	/// If the Xbox user is already linked to a player, the current session will switch to the linked player.}
	/// If the current player has previously created an account using either DeviceAuthentictionRequest or RegistrationRequest AND the Xbox user is not already registered with the game, the Xbox user will be linked to the current player.}
	/// If the current player has not authenticated and the Xbox user is not known, a new player will be created using the Xbox details and the session will be authenticated against the new player.}
	/// If the Xbox user is already known, the session will switch to being the previously created user.}
	/// </summary>
	public class XBOXLiveConnectRequest : GSTypedRequest<XBOXLiveConnectRequest,AuthenticationResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public XBOXLiveConnectRequest() : base("XBOXLiveConnectRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public XBOXLiveConnectRequest(GSInstance instance) : base(instance, "XBOXLiveConnectRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AuthenticationResponse (response);
		}
		

		/// <summary>
		/// The displayName to set for the player in GameSparks
		/// </summary>
		public XBOXLiveConnectRequest SetDisplayName( String displayName )
		{
			request.AddString("displayName", displayName);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if a new player would have been registered, rather than creating the player.  Defaults to false.
		/// </summary>
		public XBOXLiveConnectRequest SetDoNotCreateNewPlayer( bool doNotCreateNewPlayer )
		{
			request.AddBoolean("doNotCreateNewPlayer", doNotCreateNewPlayer);
			return this;
		}
		/// <summary>
		/// Indicates that the server should not try to link the external profile with the current player.  If false, links the external profile to the currently signed in player.  If true, creates a new player and links the external profile to them.  Defaults to false.
		/// </summary>
		public XBOXLiveConnectRequest SetDoNotLinkToCurrentPlayer( bool doNotLinkToCurrentPlayer )
		{
			request.AddBoolean("doNotLinkToCurrentPlayer", doNotLinkToCurrentPlayer);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if an account switch would have occurred, rather than switching automatically.  Defaults to false.
		/// </summary>
		public XBOXLiveConnectRequest SetErrorOnSwitch( bool errorOnSwitch )
		{
			request.AddBoolean("errorOnSwitch", errorOnSwitch);
			return this;
		}
		/// <summary>
		/// An optional segment configuration for this request.
		/// If this request creates a new player on the gamesparks platform, the segments of the new player will match the values provided
		/// </summary>
		public XBOXLiveConnectRequest SetSegments( GSRequestData segments )
		{
			request.AddObject("segments", segments);
			return this;
		}
		/// <summary>
		/// The access token is used by the client to make authenticated requests on behalf of the end user.
		/// It has a longer lifetime than the authorization code, typically on the order of minutes or hours.
		/// When the access token expires, attempts to use it will fail, and a new access token must be obtained via a refresh token.
		/// </summary>
		public XBOXLiveConnectRequest SetStsTokenString( String stsTokenString )
		{
			request.AddString("stsTokenString", stsTokenString);
			return this;
		}
		/// <summary>
		/// Indicates that the server should switch to the supplied profile if it isalready associated to a player. Defaults to false.
		/// </summary>
		public XBOXLiveConnectRequest SetSwitchIfPossible( bool switchIfPossible )
		{
			request.AddBoolean("switchIfPossible", switchIfPossible);
			return this;
		}
		/// <summary>
		/// Indicates that the associated players displayName should be kept in syn with this profile when it's updated by the external provider.
		/// </summary>
		public XBOXLiveConnectRequest SetSyncDisplayName( bool syncDisplayName )
		{
			request.AddBoolean("syncDisplayName", syncDisplayName);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Consumes a consumable item from Xbox Live}
	/// </summary>
	public class XboxOneBuyGoodsRequest : GSTypedRequest<XboxOneBuyGoodsRequest,BuyVirtualGoodResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public XboxOneBuyGoodsRequest() : base("XboxOneBuyGoodsRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public XboxOneBuyGoodsRequest(GSInstance instance) : base(instance, "XboxOneBuyGoodsRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new BuyVirtualGoodResponse (response);
		}
		

		/// <summary>
		/// The ISO 4217 currency code representing the real-world currency used for this transaction.
		/// </summary>
		public XboxOneBuyGoodsRequest SetCurrencyCode( String currencyCode )
		{
			request.AddString("currencyCode", currencyCode);
			return this;
		}
		/// <summary>
		/// The ID of the inventory item to consume. This should match the Xbox One product code on the virtual good.
		/// </summary>
		public XboxOneBuyGoodsRequest SetItemId( String itemId )
		{
			request.AddString("itemId", itemId);
			return this;
		}
		/// <summary>
		/// The quantity of the inventory item to consume.
		/// </summary>
		public XboxOneBuyGoodsRequest SetItemsConsumed( long itemsConsumed )
		{
			request.AddNumber("itemsConsumed", itemsConsumed);
			return this;
		}
		/// <summary>
		/// The price of this purchase
		/// </summary>
		public XboxOneBuyGoodsRequest SetSubUnitPrice( double subUnitPrice )
		{
			request.AddNumber("subUnitPrice", subUnitPrice);
			return this;
		}
		/// <summary>
		/// If set to true, the transactionId from this receipt will not be globally valdidated, this will mean replays between players are possible.
		/// It will only validate the transactionId has not been used by this player before.
		/// </summary>
		public XboxOneBuyGoodsRequest SetUniqueTransactionByPlayer( bool uniqueTransactionByPlayer )
		{
			request.AddBoolean("uniqueTransactionByPlayer", uniqueTransactionByPlayer);
			return this;
		}
				
	}
	
	
	/// <summary>
	/// Allows an Xbox One XSTS token to be used as an authentication mechanism.}
	/// Once authenticated the platform can determine the current players details from Xbox Live and store them within GameSparks.}
	/// If the Xbox One user is already linked to a player, the current session will switch to the linked player.}
	/// If the current player has previously created an account using either DeviceAuthentictionRequest or RegistrationRequest AND the Xbox One user is not already registered with the game, the Xbox One user will be linked to the current player.}
	/// If the current player has not authenticated and the Xbox One user is not known, a new player will be created using the Xbox Live details and the session will be authenticated against the new player.}
	/// If the Xbox One user is already known, the session will switch to being the previously created user.}
	/// </summary>
	public class XboxOneConnectRequest : GSTypedRequest<XboxOneConnectRequest,AuthenticationResponse>
	{
		
		/// <summary>
		/// Constructor
		/// </summary>
		public XboxOneConnectRequest() : base("XboxOneConnectRequest"){
			
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		public XboxOneConnectRequest(GSInstance instance) : base(instance, "XboxOneConnectRequest"){
			
		}
		
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AuthenticationResponse (response);
		}
		

		/// <summary>
		/// Indicates whether the server should return an error if a new player would have been registered, rather than creating the player.  Defaults to false.
		/// </summary>
		public XboxOneConnectRequest SetDoNotCreateNewPlayer( bool doNotCreateNewPlayer )
		{
			request.AddBoolean("doNotCreateNewPlayer", doNotCreateNewPlayer);
			return this;
		}
		/// <summary>
		/// Indicates that the server should not try to link the external profile with the current player.  If false, links the external profile to the currently signed in player.  If true, creates a new player and links the external profile to them.  Defaults to false.
		/// </summary>
		public XboxOneConnectRequest SetDoNotLinkToCurrentPlayer( bool doNotLinkToCurrentPlayer )
		{
			request.AddBoolean("doNotLinkToCurrentPlayer", doNotLinkToCurrentPlayer);
			return this;
		}
		/// <summary>
		/// Indicates whether the server should return an error if an account switch would have occurred, rather than switching automatically.  Defaults to false.
		/// </summary>
		public XboxOneConnectRequest SetErrorOnSwitch( bool errorOnSwitch )
		{
			request.AddBoolean("errorOnSwitch", errorOnSwitch);
			return this;
		}
		/// <summary>
		/// The Xbox Live sandbox to use. If not specified, the sandbox from the decoded token will be used.
		/// </summary>
		public XboxOneConnectRequest SetSandbox( String sandbox )
		{
			request.AddString("sandbox", sandbox);
			return this;
		}
		/// <summary>
		/// An optional segment configuration for this request.
		/// If this request creates a new player on the gamesparks platform, the segments of the new player will match the values provided
		/// </summary>
		public XboxOneConnectRequest SetSegments( GSRequestData segments )
		{
			request.AddObject("segments", segments);
			return this;
		}
		/// <summary>
		/// Indicates that the server should switch to the supplied profile if it isalready associated to a player. Defaults to false.
		/// </summary>
		public XboxOneConnectRequest SetSwitchIfPossible( bool switchIfPossible )
		{
			request.AddBoolean("switchIfPossible", switchIfPossible);
			return this;
		}
		/// <summary>
		/// Indicates that the associated players displayName should be kept in syn with this profile when it's updated by the external provider.
		/// </summary>
		public XboxOneConnectRequest SetSyncDisplayName( bool syncDisplayName )
		{
			request.AddBoolean("syncDisplayName", syncDisplayName);
			return this;
		}
		/// <summary>
		/// The Xbox One authentication token
		/// </summary>
		public XboxOneConnectRequest SetToken( String token )
		{
			request.AddString("token", token);
			return this;
		}
				
	}
	
	
}

