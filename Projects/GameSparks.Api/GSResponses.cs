
using System;
using System.Collections.Generic;
using GameSparks.Core;

#pragma warning disable 612,618

//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!

namespace GameSparks.Api.Responses
{
	
	
	public class AcceptChallengeResponse : GSTypedResponse
	{
		public AcceptChallengeResponse(GSData data) : base(data){}
			/// <summary>
			/// The ID of the challenge
			/// </summary>
					public String ChallengeInstanceId{
						get{return response.GetString("challengeInstanceId");}
					}
	}
	
	
	public class AccountDetailsResponse : GSTypedResponse
	{
		public AccountDetailsResponse(GSData data) : base(data){}
		/// <summary>
		/// Location details.
		/// This product includes GeoLite data created by MaxMind, available from <a href="http://www.maxmind.com">http://www.maxmind.com</a>.
		/// </summary>
		public class _Location : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Location(GSData data) : base(data){}
			
			/// <summary>
			/// The city
			/// </summary>
					public String City{
						get{return response.GetString("city");}
					}
			/// <summary>
			/// The country
			/// </summary>
					public String Country{
						get{return response.GetString("country");}
					}
			/// <summary>
			/// The latitude
			/// </summary>
					public double? Latitide{
						get{return response.GetFloat("latitide");}
					}
			/// <summary>
			/// The longditute
			/// </summary>
					public double? Longditute{
						get{return response.GetFloat("longditute");}
					}
			
			
		}
			/// <summary>
			/// A JSON object containing the player's achievments
			/// </summary>
						public List<String> Achievements{
							get{ return response.GetStringList("achievements");}
						}
			/// <summary>
			/// A JSON object containing the player's currency balances
			/// </summary>
					public GSData Currencies{
						get{return response.GetObject("currencies");}
					}
			/// <summary>
			/// The amount of type 1 currency that the player holds
			/// </summary>
					public long? Currency1{
						get{return response.GetLong("currency1");}
					}
			/// <summary>
			/// The amount of type 2 currency that the player holds
			/// </summary>
					public long? Currency2{
						get{return response.GetLong("currency2");}
					}
			/// <summary>
			/// The amount of type 3 currency that the player holds
			/// </summary>
					public long? Currency3{
						get{return response.GetLong("currency3");}
					}
			/// <summary>
			/// The amount of type 4 currency that the player holds
			/// </summary>
					public long? Currency4{
						get{return response.GetLong("currency4");}
					}
			/// <summary>
			/// The amount of type 5 currency that the player holds
			/// </summary>
					public long? Currency5{
						get{return response.GetLong("currency5");}
					}
			/// <summary>
			/// The amount of type 6 currency that the player holds
			/// </summary>
					public long? Currency6{
						get{return response.GetLong("currency6");}
					}
			/// <summary>
			/// The player's display name
			/// </summary>
					public String DisplayName{
						get{return response.GetString("displayName");}
					}
			/// <summary>
			/// A JSON object containing the player's external account details
			/// </summary>
					public GSData ExternalIds{
						get{return response.GetObject("externalIds");}
					}
			/// <summary>
			/// A JSON object containing the player's location
			/// </summary>
					public _Location Location{
						get{
							if(response.GetObject("location") == null) { return null; }
							return new _Location(response.GetObject("location"));
						}
					}
			/// <summary>
			/// A JSON object containing the player's currency balances
			/// </summary>
					public GSData ReservedCurrencies{
						get{return response.GetObject("reservedCurrencies");}
					}
			/// <summary>
			/// The amount of type 1 currency that the player holds which is currently reserved
			/// </summary>
					public GSData ReservedCurrency1{
						get{return response.GetObject("reservedCurrency1");}
					}
			/// <summary>
			/// The amount of type 2 currency that the player holds which is currently reserved
			/// </summary>
					public GSData ReservedCurrency2{
						get{return response.GetObject("reservedCurrency2");}
					}
			/// <summary>
			/// The amount of type 3 currency that the player holds which is currently reserved
			/// </summary>
					public GSData ReservedCurrency3{
						get{return response.GetObject("reservedCurrency3");}
					}
			/// <summary>
			/// The amount of type 4 currency that the player holds which is currently reserved
			/// </summary>
					public GSData ReservedCurrency4{
						get{return response.GetObject("reservedCurrency4");}
					}
			/// <summary>
			/// The amount of type 5 currency that the player holds which is currently reserved
			/// </summary>
					public GSData ReservedCurrency5{
						get{return response.GetObject("reservedCurrency5");}
					}
			/// <summary>
			/// The amount of type 6 currency that the player holds which is currently reserved
			/// </summary>
					public GSData ReservedCurrency6{
						get{return response.GetObject("reservedCurrency6");}
					}
			/// <summary>
			/// The player's id
			/// </summary>
					public String UserId{
						get{return response.GetString("userId");}
					}
			/// <summary>
			/// A JSON object containing the virtual goods that the player owns
			/// </summary>
					public GSData VirtualGoods{
						get{return response.GetObject("virtualGoods");}
					}
	}
	
	
	public class AnalyticsResponse : GSTypedResponse
	{
		public AnalyticsResponse(GSData data) : base(data){}
	}
	
	
	public class AroundMeLeaderboardResponse : GSTypedResponse
	{
		public AroundMeLeaderboardResponse(GSData data) : base(data){}
		/// <summary>
		/// Leaderboard entry data
		/// As well as the parameters below there may be others depending on your game's configuration.
		/// </summary>
		public class _LeaderboardData : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _LeaderboardData(GSData data) : base(data){}
			
			/// <summary>
			/// The city where the player was located when they logged this leaderboard entry.
			/// </summary>
					public String City{
						get{return response.GetString("city");}
					}
			/// <summary>
			/// The country code where the player was located when they logged this leaderboard entry.
			/// </summary>
					public String Country{
						get{return response.GetString("country");}
					}
			/// <summary>
			/// The players rank.
			/// </summary>
					public GSData ExternalIds{
						get{return response.GetObject("externalIds");}
					}
			/// <summary>
			/// The players rank.
			/// </summary>
					public long? Rank{
						get{return response.GetLong("rank");}
					}
			/// <summary>
			/// The unique player id for this leaderboard entry.
			/// </summary>
					public String UserId{
						get{return response.GetString("userId");}
					}
			/// <summary>
			/// The players display name.
			/// </summary>
					public String UserName{
						get{return response.GetString("userName");}
					}
			/// <summary>
			/// The date when this leaderboard entry was created.
			/// </summary>
					public String When{
						get{return response.GetString("when");}
					}
			
			public long? GetNumberValue(String key){
				return response.GetLong(key);
			}
			
			public string GetStringValue(String key){
				return response.GetString(key);
			}
			
		}
			/// <summary>
			/// The leaderboard's challenge id
			/// </summary>
					public String ChallengeInstanceId{
						get{return response.GetString("challengeInstanceId");}
					}
			/// <summary>
			/// The leaderboard data
			/// </summary>
					public GSEnumerable<_LeaderboardData> Data{
						get{return new GSEnumerable<_LeaderboardData>(response.GetObjectList("data"), (data) => { return new _LeaderboardData(data);});}
					}
			/// <summary>
			/// The first item in the leaderboard data
			/// </summary>
					public GSEnumerable<_LeaderboardData> First{
						get{return new GSEnumerable<_LeaderboardData>(response.GetObjectList("first"), (data) => { return new _LeaderboardData(data);});}
					}
			/// <summary>
			/// The last item in the leaderboard data
			/// </summary>
					public GSEnumerable<_LeaderboardData> Last{
						get{return new GSEnumerable<_LeaderboardData>(response.GetObjectList("last"), (data) => { return new _LeaderboardData(data);});}
					}
			/// <summary>
			/// The leaderboard short code
			/// </summary>
					public String LeaderboardShortCode{
						get{return response.GetString("leaderboardShortCode");}
					}
			/// <summary>
			/// True if the response contains a social leaderboard's data
			/// </summary>
					public bool? Social{
						get{return response.GetBoolean("social");}
					}
	}
	
	
	public class AuthenticationResponse : GSTypedResponse
	{
		public AuthenticationResponse(GSData data) : base(data){}
		/// <summary>
		/// A nested object that represents a player.
		/// </summary>
		public class _Player : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Player(GSData data) : base(data){}
			
			/// <summary>
			/// The achievements of the Player
			/// </summary>
						public List<String> Achievements{
							get{ return response.GetStringList("achievements");}
						}
			/// <summary>
			/// The display name of the Player
			/// </summary>
					public String DisplayName{
						get{return response.GetString("displayName");}
					}
			/// <summary>
			/// The external Id's of the Player
			/// </summary>
					public GSData ExternalIds{
						get{return response.GetObject("externalIds");}
					}
			/// <summary>
			/// The Id of the Player
			/// </summary>
					public String Id{
						get{return response.GetString("id");}
					}
			/// <summary>
			/// The online status of the Player
			/// </summary>
					public bool? Online{
						get{return response.GetBoolean("online");}
					}
			/// <summary>
			/// The virtual goods of the Player
			/// </summary>
						public List<String> VirtualGoods{
							get{ return response.GetStringList("virtualGoods");}
						}
			
			
		}
			/// <summary>
			/// 44b297a8-162a-4220-8c14-dad9a1946ad2
			/// </summary>
					public String AuthToken{
						get{return response.GetString("authToken");}
					}
			/// <summary>
			/// The player's display name
			/// </summary>
					public String DisplayName{
						get{return response.GetString("displayName");}
					}
			/// <summary>
			/// Indicates whether the player was created as part of this request
			/// </summary>
					public bool? NewPlayer{
						get{return response.GetBoolean("newPlayer");}
					}
			/// <summary>
			/// A summary of the player that would be switched to.  Only returned as part of an error response for a request where automatic switching is disabled.
			/// </summary>
					public _Player SwitchSummary{
						get{
							if(response.GetObject("switchSummary") == null) { return null; }
							return new _Player(response.GetObject("switchSummary"));
						}
					}
			/// <summary>
			/// The player's id
			/// </summary>
					public String UserId{
						get{return response.GetString("userId");}
					}
	}
	
	
	public class BatchAdminResponse : GSTypedResponse
	{
		public BatchAdminResponse(GSData data) : base(data){}
			/// <summary>
			/// A map of responses by player ID
			/// </summary>
					public GSData Responses{
						get{return response.GetObject("responses");}
					}
	}
	
	
	public class BuyVirtualGoodResponse : GSTypedResponse
	{
		public BuyVirtualGoodResponse(GSData data) : base(data){}
		/// <summary>
		/// A nested object that represents a bought item.
		/// </summary>
		public class _Boughtitem : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Boughtitem(GSData data) : base(data){}
			
			/// <summary>
			/// The quantity of the bought item
			/// </summary>
					public long? Quantity{
						get{return response.GetLong("quantity");}
					}
			/// <summary>
			/// The short code of the bought item
			/// </summary>
					public String ShortCode{
						get{return response.GetString("shortCode");}
					}
			
			
		}
			/// <summary>
			/// A JSON object containing details of the bought items
			/// </summary>
					public GSEnumerable<_Boughtitem> BoughtItems{
						get{return new GSEnumerable<_Boughtitem>(response.GetObjectList("boughtItems"), (data) => { return new _Boughtitem(data);});}
					}
			/// <summary>
			/// An object containing the short code and amount added for each currency
			/// </summary>
					public GSData CurrenciesAdded{
						get{return response.GetObject("currenciesAdded");}
					}
			/// <summary>
			/// How much currency type 1 was added
			/// </summary>
					public long? Currency1Added{
						get{return response.GetLong("currency1Added");}
					}
			/// <summary>
			/// How much currency type 2 was added
			/// </summary>
					public long? Currency2Added{
						get{return response.GetLong("currency2Added");}
					}
			/// <summary>
			/// How much currency type 3 was added
			/// </summary>
					public long? Currency3Added{
						get{return response.GetLong("currency3Added");}
					}
			/// <summary>
			/// How much currency type 4 was added
			/// </summary>
					public long? Currency4Added{
						get{return response.GetLong("currency4Added");}
					}
			/// <summary>
			/// How much currency type 5 was added
			/// </summary>
					public long? Currency5Added{
						get{return response.GetLong("currency5Added");}
					}
			/// <summary>
			/// How much currency type 6 was added
			/// </summary>
					public long? Currency6Added{
						get{return response.GetLong("currency6Added");}
					}
			/// <summary>
			/// For a buy with currency request, how much currency was used
			/// </summary>
					public long? CurrencyConsumed{
						get{return response.GetLong("currencyConsumed");}
					}
			/// <summary>
			/// For a buy with currency request, the short code of the currency used
			/// </summary>
					public String CurrencyShortCode{
						get{return response.GetString("currencyShortCode");}
					}
			/// <summary>
			/// For a buy with currency request, which currency type was used
			/// </summary>
					public int? CurrencyType{
						get{return response.GetInt("currencyType");}
					}
			/// <summary>
			/// A list of invalid items for this purchase (if any). This field is populated only for store buys
			/// </summary>
						public List<String> InvalidItems{
							get{ return response.GetStringList("invalidItems");}
						}
			/// <summary>
			/// The list of transactionIds, for this purchase, if they exist. This field is populated only for store buys
			/// </summary>
						public List<String> TransactionIds{
							get{ return response.GetStringList("transactionIds");}
						}
	}
	
	
	public class CancelBulkJobAdminResponse : GSTypedResponse
	{
		public CancelBulkJobAdminResponse(GSData data) : base(data){}
		/// <summary>
		/// A nested object that represents the bulk job.
		/// </summary>
		public class _BulkJob : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _BulkJob(GSData data) : base(data){}
			
			/// <summary>
			/// The actual count of players affected by the bulk job (calculated when the job started to run)
			/// </summary>
					public long? ActualCount{
						get{return response.GetLong("actualCount");}
					}
			/// <summary>
			/// The time at which the bulk job completed execution
			/// </summary>
					public DateTime? Completed{
						get{return response.GetDate("completed");}
					}
			/// <summary>
			/// The time at which the bulk job was created
			/// </summary>
					public DateTime? Created{
						get{return response.GetDate("created");}
					}
			/// <summary>
			/// Data to be passed into the Module or Script
			/// </summary>
					public GSData Data{
						get{return response.GetObject("data");}
					}
			/// <summary>
			/// The number of players processed by the bulk job so far
			/// </summary>
					public long? DoneCount{
						get{return response.GetLong("doneCount");}
					}
			/// <summary>
			/// The number of errors encountered whilst running the Module or Script for players
			/// </summary>
					public long? ErrorCount{
						get{return response.GetLong("errorCount");}
					}
			/// <summary>
			/// The estimated count of players affected by the bulk job (estimated when the job was submitted)
			/// </summary>
					public long? EstimatedCount{
						get{return response.GetLong("estimatedCount");}
					}
			/// <summary>
			/// The ID for the bulk job
			/// </summary>
					public String Id{
						get{return response.GetString("id");}
					}
			/// <summary>
			/// The Cloud Code Module to run for each player
			/// </summary>
					public String ModuleShortCode{
						get{return response.GetString("moduleShortCode");}
					}
			/// <summary>
			/// The query to identify players to perform the bulk job on
			/// </summary>
					public GSData PlayerQuery{
						get{return response.GetObject("playerQuery");}
					}
			/// <summary>
			/// The time at which the job was scheduled to run
			/// </summary>
					public DateTime? ScheduledTime{
						get{return response.GetDate("scheduledTime");}
					}
			/// <summary>
			/// The Cloud Code script to run for each player
			/// </summary>
					public String Script{
						get{return response.GetString("script");}
					}
			/// <summary>
			/// The time at which the bulk job started to execute
			/// </summary>
					public DateTime? Started{
						get{return response.GetDate("started");}
					}
			/// <summary>
			/// The current state of the bulk job
			/// </summary>
					public String State{
						get{return response.GetString("state");}
					}
			
			
		}
			/// <summary>
			/// A list of JSON objects containing bulk jobs
			/// </summary>
					public GSEnumerable<_BulkJob> BulkJobs{
						get{return new GSEnumerable<_BulkJob>(response.GetObjectList("bulkJobs"), (data) => { return new _BulkJob(data);});}
					}
	}
	
	
	public class ChangeUserDetailsResponse : GSTypedResponse
	{
		public ChangeUserDetailsResponse(GSData data) : base(data){}
	}
	
	
	public class ChatOnChallengeResponse : GSTypedResponse
	{
		public ChatOnChallengeResponse(GSData data) : base(data){}
			/// <summary>
			/// The challenge instance id
			/// </summary>
					public String ChallengeInstanceId{
						get{return response.GetString("challengeInstanceId");}
					}
	}
	
	
	public class ConsumeVirtualGoodResponse : GSTypedResponse
	{
		public ConsumeVirtualGoodResponse(GSData data) : base(data){}
	}
	
	
	public class CreateChallengeResponse : GSTypedResponse
	{
		public CreateChallengeResponse(GSData data) : base(data){}
			/// <summary>
			/// The challenge instance id
			/// </summary>
					public String ChallengeInstanceId{
						get{return response.GetString("challengeInstanceId");}
					}
	}
	
	
	public class CreateTeamResponse : GSTypedResponse
	{
		public CreateTeamResponse(GSData data) : base(data){}
		/// <summary>
		/// A nested object that represents a player.
		/// </summary>
		public class _Player : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Player(GSData data) : base(data){}
			
			/// <summary>
			/// The achievements of the Player
			/// </summary>
						public List<String> Achievements{
							get{ return response.GetStringList("achievements");}
						}
			/// <summary>
			/// The display name of the Player
			/// </summary>
					public String DisplayName{
						get{return response.GetString("displayName");}
					}
			/// <summary>
			/// The external Id's of the Player
			/// </summary>
					public GSData ExternalIds{
						get{return response.GetObject("externalIds");}
					}
			/// <summary>
			/// The Id of the Player
			/// </summary>
					public String Id{
						get{return response.GetString("id");}
					}
			/// <summary>
			/// The online status of the Player
			/// </summary>
					public bool? Online{
						get{return response.GetBoolean("online");}
					}
			/// <summary>
			/// The virtual goods of the Player
			/// </summary>
						public List<String> VirtualGoods{
							get{ return response.GetStringList("virtualGoods");}
						}
			
			
		}
			/// <summary>
			/// The team members
			/// </summary>
					public GSEnumerable<_Player> Members{
						get{return new GSEnumerable<_Player>(response.GetObjectList("members"), (data) => { return new _Player(data);});}
					}
			/// <summary>
			/// A summary of the owner
			/// </summary>
					public _Player Owner{
						get{
							if(response.GetObject("owner") == null) { return null; }
							return new _Player(response.GetObject("owner"));
						}
					}
			/// <summary>
			/// The Id of the team
			/// </summary>
					public String TeamId{
						get{return response.GetString("teamId");}
					}
			/// <summary>
			/// The team name
			/// </summary>
					public String TeamName{
						get{return response.GetString("teamName");}
					}
			/// <summary>
			/// The team type
			/// </summary>
					public String TeamType{
						get{return response.GetString("teamType");}
					}
	}
	
	
	public class DeclineChallengeResponse : GSTypedResponse
	{
		public DeclineChallengeResponse(GSData data) : base(data){}
			/// <summary>
			/// The challenge instance id
			/// </summary>
					public String ChallengeInstanceId{
						get{return response.GetString("challengeInstanceId");}
					}
	}
	
	
	public class DismissMessageResponse : GSTypedResponse
	{
		public DismissMessageResponse(GSData data) : base(data){}
	}
	
	
	public class DismissMultipleMessagesResponse : GSTypedResponse
	{
		public DismissMultipleMessagesResponse(GSData data) : base(data){}
			/// <summary>
			/// A list of the messageId values that were not dismissed
			/// </summary>
						public List<String> FailedDismissals{
							get{ return response.GetStringList("failedDismissals");}
						}
			/// <summary>
			/// An integer describing how many messages were dismissed
			/// </summary>
					public int? MessagesDismissed{
						get{return response.GetInt("messagesDismissed");}
					}
	}
	
	
	public class DropTeamResponse : GSTypedResponse
	{
		public DropTeamResponse(GSData data) : base(data){}
	}
	
	
	public class EndSessionResponse : GSTypedResponse
	{
		public EndSessionResponse(GSData data) : base(data){}
			/// <summary>
			/// The length of this session
			/// </summary>
					public long? SessionDuration{
						get{return response.GetLong("sessionDuration");}
					}
	}
	
	
	public class FindChallengeResponse : GSTypedResponse
	{
		public FindChallengeResponse(GSData data) : base(data){}
		/// <summary>
		/// A nested object that represents the challenge data.
		/// </summary>
		public class _Challenge : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Challenge(GSData data) : base(data){}
			
		/// <summary>
		/// An object representing a player's id and name
		/// </summary>
		public class _PlayerDetail : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _PlayerDetail(GSData data) : base(data){}
			
			/// <summary>
			/// A player's external identifiers
			/// </summary>
					public GSData ExternalIds{
						get{return response.GetObject("externalIds");}
					}
			/// <summary>
			/// A player's id
			/// </summary>
					public String Id{
						get{return response.GetString("id");}
					}
			/// <summary>
			/// A player's name
			/// </summary>
					public String Name{
						get{return response.GetString("name");}
					}
			
			
		}
		/// <summary>
		/// Represents the number of turns a player has taken in a turn based challenge.
		/// </summary>
		public class _PlayerTurnCount : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _PlayerTurnCount(GSData data) : base(data){}
			
			/// <summary>
			/// The number of turns that the player has taken so far during this challenge.
			/// </summary>
					public String Count{
						get{return response.GetString("count");}
					}
			/// <summary>
			/// The unique player id.
			/// </summary>
					public String PlayerId{
						get{return response.GetString("playerId");}
					}
			
			
		}
			/// <summary>
			/// A list of PlayerDetail objects that represents the players that have accepted this challenge.
			/// </summary>
					public GSEnumerable<_PlayerDetail> Accepted{
						get{return new GSEnumerable<_PlayerDetail>(response.GetObjectList("accepted"), (data) => { return new _PlayerDetail(data);});}
					}
			/// <summary>
			/// A unique identifier for this challenge.
			/// </summary>
					public String ChallengeId{
						get{return response.GetString("challengeId");}
					}
			/// <summary>
			/// The message included in the challenge by the challenging player who created the challenge.
			/// </summary>
					public String ChallengeMessage{
						get{return response.GetString("challengeMessage");}
					}
			/// <summary>
			/// The name of the challenge that this message relates to.
			/// </summary>
					public String ChallengeName{
						get{return response.GetString("challengeName");}
					}
			/// <summary>
			/// A list of PlayerDetail objects that represents the players that were challenged in this challenge.
			/// </summary>
					public GSEnumerable<_PlayerDetail> Challenged{
						get{return new GSEnumerable<_PlayerDetail>(response.GetObjectList("challenged"), (data) => { return new _PlayerDetail(data);});}
					}
			/// <summary>
			/// Details of the player who issued this challenge.
			/// </summary>
					public _PlayerDetail Challenger{
						get{
							if(response.GetObject("challenger") == null) { return null; }
							return new _PlayerDetail(response.GetObject("challenger"));
						}
					}
			/// <summary>
			/// The amount of type 1 currency that has been wagered on this challenge.
			/// </summary>
					public long? Currency1Wager{
						get{return response.GetLong("currency1Wager");}
					}
			/// <summary>
			/// The amount of type 2 currency that has been wagered on this challenge.
			/// </summary>
					public long? Currency2Wager{
						get{return response.GetLong("currency2Wager");}
					}
			/// <summary>
			/// The amount of type 3 currency that has been wagered on this challenge.
			/// </summary>
					public long? Currency3Wager{
						get{return response.GetLong("currency3Wager");}
					}
			/// <summary>
			/// The amount of type 4 currency that has been wagered on this challenge.
			/// </summary>
					public long? Currency4Wager{
						get{return response.GetLong("currency4Wager");}
					}
			/// <summary>
			/// The amount of type 5 currency that has been wagered on this challenge.
			/// </summary>
					public long? Currency5Wager{
						get{return response.GetLong("currency5Wager");}
					}
			/// <summary>
			/// The amount of type 6 currency that has been wagered on this challenge.
			/// </summary>
					public long? Currency6Wager{
						get{return response.GetLong("currency6Wager");}
					}
			/// <summary>
			/// An object representing the currencies that have been wagered on this challenge.
			/// </summary>
					public GSData CurrencyWagers{
						get{return response.GetObject("currencyWagers");}
					}
			/// <summary>
			/// A list of PlayerDetail objects that represents the players that have declined this challenge.
			/// </summary>
					public GSEnumerable<_PlayerDetail> Declined{
						get{return new GSEnumerable<_PlayerDetail>(response.GetObjectList("declined"), (data) => { return new _PlayerDetail(data);});}
					}
			/// <summary>
			/// The date when the challenge ends.
			/// </summary>
					public DateTime? EndDate{
						get{return response.GetDate("endDate");}
					}
			/// <summary>
			/// The latest date that a player can accept the challenge.
			/// </summary>
					public DateTime? ExpiryDate{
						get{return response.GetDate("expiryDate");}
					}
			/// <summary>
			/// The maximum number of turns that this challenge is configured for.
			/// </summary>
					public long? MaxTurns{
						get{return response.GetLong("maxTurns");}
					}
			/// <summary>
			/// In a turn based challenge this fields contains the player's id whose turn it is next.
			/// </summary>
					public String NextPlayer{
						get{return response.GetString("nextPlayer");}
					}
			/// <summary>
			/// The challenge's short code.
			/// </summary>
					public String ShortCode{
						get{return response.GetString("shortCode");}
					}
			/// <summary>
			/// The date when the challenge starts.
			/// </summary>
					public DateTime? StartDate{
						get{return response.GetDate("startDate");}
					}
			/// <summary>
			/// One of these possible state values: ISSUED, EXPIRED, ACCEPTED, DECLINED, COMPLETE, WITHDRAWN, RUNNING, WAITING, RECEIVED
			/// </summary>
					public String State{
						get{return response.GetString("state");}
					}
			/// <summary>
			/// A collection containing the number of turns taken by each player that has accepted the challenge.
			/// Each turn count is a Long keyed on a String that represents the player's id
			/// </summary>
					public GSEnumerable<_PlayerTurnCount> TurnCount{
						get{return new GSEnumerable<_PlayerTurnCount>(response.GetObjectList("turnCount"), (data) => { return new _PlayerTurnCount(data);});}
					}
			
			
		}
			/// <summary>
			/// A list of JSON objects representing the challenges.
			/// </summary>
					public GSEnumerable<_Challenge> ChallengeInstances{
						get{return new GSEnumerable<_Challenge>(response.GetObjectList("challengeInstances"), (data) => { return new _Challenge(data);});}
					}
	}
	
	
	public class FindMatchResponse : GSTypedResponse
	{
		public FindMatchResponse(GSData data) : base(data){}
		/// <summary>
		/// A nested object that represents a player.
		/// </summary>
		public class _Player : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Player(GSData data) : base(data){}
			
			/// <summary>
			/// The achievements of the Player
			/// </summary>
						public List<String> Achievements{
							get{ return response.GetStringList("achievements");}
						}
			/// <summary>
			/// The display name of the Player
			/// </summary>
					public String DisplayName{
						get{return response.GetString("displayName");}
					}
			/// <summary>
			/// The external Id's of the Player
			/// </summary>
					public GSData ExternalIds{
						get{return response.GetObject("externalIds");}
					}
			/// <summary>
			/// The Id of the Player
			/// </summary>
					public String Id{
						get{return response.GetString("id");}
					}
			/// <summary>
			/// The online status of the Player
			/// </summary>
					public bool? Online{
						get{return response.GetBoolean("online");}
					}
			/// <summary>
			/// The virtual goods of the Player
			/// </summary>
						public List<String> VirtualGoods{
							get{ return response.GetStringList("virtualGoods");}
						}
			
			
		}
			/// <summary>
			/// The accessToken used to authenticate this player for this match
			/// </summary>
					public String AccessToken{
						get{return response.GetString("accessToken");}
					}
			/// <summary>
			/// The host to connect to for this match
			/// </summary>
					public String Host{
						get{return response.GetString("host");}
					}
			/// <summary>
			/// MatchData is arbitrary data that can be stored in a Match instance by a Cloud Code script.
			/// </summary>
					public GSData MatchData{
						get{return response.GetObject("matchData");}
					}
			/// <summary>
			/// The id for this match instance
			/// </summary>
					public String MatchId{
						get{return response.GetString("matchId");}
					}
			/// <summary>
			/// The opponents this player has been matched against
			/// </summary>
					public GSEnumerable<_Player> Opponents{
						get{return new GSEnumerable<_Player>(response.GetObjectList("opponents"), (data) => { return new _Player(data);});}
					}
			/// <summary>
			/// The peerId of this player within the match
			/// </summary>
					public int? PeerId{
						get{return response.GetInt("peerId");}
					}
			/// <summary>
			/// The id of the current player
			/// </summary>
					public String PlayerId{
						get{return response.GetString("playerId");}
					}
			/// <summary>
			/// The port to connect to for this match
			/// </summary>
					public int? Port{
						get{return response.GetInt("port");}
					}
	}
	
	
	public class FindPendingMatchesResponse : GSTypedResponse
	{
		public FindPendingMatchesResponse(GSData data) : base(data){}
		/// <summary>
		/// An object that represents a pending match.
		/// </summary>
		public class _PendingMatch : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _PendingMatch(GSData data) : base(data){}
			
		/// <summary>
		/// An object that represents a player in a pending match.
		/// </summary>
		public class _MatchedPlayer : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _MatchedPlayer(GSData data) : base(data){}
			
			/// <summary>
			/// The Location of the player
			/// </summary>
					public GSData Location{
						get{return response.GetObject("location");}
					}
			/// <summary>
			/// A JSON Map of any data that was associated to this user
			/// </summary>
					public GSData ParticipantData{
						get{return response.GetObject("participantData");}
					}
			/// <summary>
			/// The ID for player
			/// </summary>
					public String PlayerId{
						get{return response.GetString("playerId");}
					}
			/// <summary>
			/// The skill of the player in this match
			/// </summary>
					public double? Skill{
						get{return response.GetDouble("skill");}
					}
			
			
		}
			/// <summary>
			/// The ID for the pending match
			/// </summary>
					public String Id{
						get{return response.GetString("id");}
					}
			/// <summary>
			/// A JSON Map of the matchData associated to this pending match
			/// </summary>
					public GSData MatchData{
						get{return response.GetObject("matchData");}
					}
			/// <summary>
			/// The match group for the pending match
			/// </summary>
					public String MatchGroup{
						get{return response.GetString("matchGroup");}
					}
			/// <summary>
			/// The match shortCode for the pending match
			/// </summary>
					public String MatchShortCode{
						get{return response.GetString("matchShortCode");}
					}
			/// <summary>
			/// The players already part of this pending match
			/// </summary>
					public GSEnumerable<_MatchedPlayer> MatchedPlayers{
						get{return new GSEnumerable<_MatchedPlayer>(response.GetObjectList("matchedPlayers"), (data) => { return new _MatchedPlayer(data);});}
					}
			/// <summary>
			/// The average skill of players in this pending match
			/// </summary>
					public double? Skill{
						get{return response.GetDouble("skill");}
					}
			
			
		}
			/// <summary>
			/// A list of JSON objects containing pending matches
			/// </summary>
					public GSEnumerable<_PendingMatch> PendingMatches{
						get{return new GSEnumerable<_PendingMatch>(response.GetObjectList("pendingMatches"), (data) => { return new _PendingMatch(data);});}
					}
	}
	
	
	public class GameSparksErrorResponse : GSTypedResponse
	{
		public GameSparksErrorResponse(GSData data) : base(data){}
	}
	
	
	public class GetChallengeResponse : GSTypedResponse
	{
		public GetChallengeResponse(GSData data) : base(data){}
		/// <summary>
		/// A nested object that represents the challenge data.
		/// </summary>
		public class _Challenge : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Challenge(GSData data) : base(data){}
			
		/// <summary>
		/// An object representing a player's id and name
		/// </summary>
		public class _PlayerDetail : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _PlayerDetail(GSData data) : base(data){}
			
			/// <summary>
			/// A player's external identifiers
			/// </summary>
					public GSData ExternalIds{
						get{return response.GetObject("externalIds");}
					}
			/// <summary>
			/// A player's id
			/// </summary>
					public String Id{
						get{return response.GetString("id");}
					}
			/// <summary>
			/// A player's name
			/// </summary>
					public String Name{
						get{return response.GetString("name");}
					}
			
			
		}
		/// <summary>
		/// Represents the number of turns a player has taken in a turn based challenge.
		/// </summary>
		public class _PlayerTurnCount : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _PlayerTurnCount(GSData data) : base(data){}
			
			/// <summary>
			/// The number of turns that the player has taken so far during this challenge.
			/// </summary>
					public String Count{
						get{return response.GetString("count");}
					}
			/// <summary>
			/// The unique player id.
			/// </summary>
					public String PlayerId{
						get{return response.GetString("playerId");}
					}
			
			
		}
			/// <summary>
			/// A list of PlayerDetail objects that represents the players that have accepted this challenge.
			/// </summary>
					public GSEnumerable<_PlayerDetail> Accepted{
						get{return new GSEnumerable<_PlayerDetail>(response.GetObjectList("accepted"), (data) => { return new _PlayerDetail(data);});}
					}
			/// <summary>
			/// A unique identifier for this challenge.
			/// </summary>
					public String ChallengeId{
						get{return response.GetString("challengeId");}
					}
			/// <summary>
			/// The message included in the challenge by the challenging player who created the challenge.
			/// </summary>
					public String ChallengeMessage{
						get{return response.GetString("challengeMessage");}
					}
			/// <summary>
			/// The name of the challenge that this message relates to.
			/// </summary>
					public String ChallengeName{
						get{return response.GetString("challengeName");}
					}
			/// <summary>
			/// A list of PlayerDetail objects that represents the players that were challenged in this challenge.
			/// </summary>
					public GSEnumerable<_PlayerDetail> Challenged{
						get{return new GSEnumerable<_PlayerDetail>(response.GetObjectList("challenged"), (data) => { return new _PlayerDetail(data);});}
					}
			/// <summary>
			/// Details of the player who issued this challenge.
			/// </summary>
					public _PlayerDetail Challenger{
						get{
							if(response.GetObject("challenger") == null) { return null; }
							return new _PlayerDetail(response.GetObject("challenger"));
						}
					}
			/// <summary>
			/// The amount of type 1 currency that has been wagered on this challenge.
			/// </summary>
					public long? Currency1Wager{
						get{return response.GetLong("currency1Wager");}
					}
			/// <summary>
			/// The amount of type 2 currency that has been wagered on this challenge.
			/// </summary>
					public long? Currency2Wager{
						get{return response.GetLong("currency2Wager");}
					}
			/// <summary>
			/// The amount of type 3 currency that has been wagered on this challenge.
			/// </summary>
					public long? Currency3Wager{
						get{return response.GetLong("currency3Wager");}
					}
			/// <summary>
			/// The amount of type 4 currency that has been wagered on this challenge.
			/// </summary>
					public long? Currency4Wager{
						get{return response.GetLong("currency4Wager");}
					}
			/// <summary>
			/// The amount of type 5 currency that has been wagered on this challenge.
			/// </summary>
					public long? Currency5Wager{
						get{return response.GetLong("currency5Wager");}
					}
			/// <summary>
			/// The amount of type 6 currency that has been wagered on this challenge.
			/// </summary>
					public long? Currency6Wager{
						get{return response.GetLong("currency6Wager");}
					}
			/// <summary>
			/// An object representing the currencies that have been wagered on this challenge.
			/// </summary>
					public GSData CurrencyWagers{
						get{return response.GetObject("currencyWagers");}
					}
			/// <summary>
			/// A list of PlayerDetail objects that represents the players that have declined this challenge.
			/// </summary>
					public GSEnumerable<_PlayerDetail> Declined{
						get{return new GSEnumerable<_PlayerDetail>(response.GetObjectList("declined"), (data) => { return new _PlayerDetail(data);});}
					}
			/// <summary>
			/// The date when the challenge ends.
			/// </summary>
					public DateTime? EndDate{
						get{return response.GetDate("endDate");}
					}
			/// <summary>
			/// The latest date that a player can accept the challenge.
			/// </summary>
					public DateTime? ExpiryDate{
						get{return response.GetDate("expiryDate");}
					}
			/// <summary>
			/// The maximum number of turns that this challenge is configured for.
			/// </summary>
					public long? MaxTurns{
						get{return response.GetLong("maxTurns");}
					}
			/// <summary>
			/// In a turn based challenge this fields contains the player's id whose turn it is next.
			/// </summary>
					public String NextPlayer{
						get{return response.GetString("nextPlayer");}
					}
			/// <summary>
			/// The challenge's short code.
			/// </summary>
					public String ShortCode{
						get{return response.GetString("shortCode");}
					}
			/// <summary>
			/// The date when the challenge starts.
			/// </summary>
					public DateTime? StartDate{
						get{return response.GetDate("startDate");}
					}
			/// <summary>
			/// One of these possible state values: ISSUED, EXPIRED, ACCEPTED, DECLINED, COMPLETE, WITHDRAWN, RUNNING, WAITING, RECEIVED
			/// </summary>
					public String State{
						get{return response.GetString("state");}
					}
			/// <summary>
			/// A collection containing the number of turns taken by each player that has accepted the challenge.
			/// Each turn count is a Long keyed on a String that represents the player's id
			/// </summary>
					public GSEnumerable<_PlayerTurnCount> TurnCount{
						get{return new GSEnumerable<_PlayerTurnCount>(response.GetObjectList("turnCount"), (data) => { return new _PlayerTurnCount(data);});}
					}
			
			
		}
			/// <summary>
			/// A JSON object representing the challenge.
			/// </summary>
					public _Challenge Challenge{
						get{
							if(response.GetObject("challenge") == null) { return null; }
							return new _Challenge(response.GetObject("challenge"));
						}
					}
	}
	
	
	public class GetDownloadableResponse : GSTypedResponse
	{
		public GetDownloadableResponse(GSData data) : base(data){}
			/// <summary>
			/// The date when the downloadable item was last modified
			/// </summary>
					public DateTime? LastModified{
						get{return response.GetDate("lastModified");}
					}
			/// <summary>
			/// The short code of the item
			/// </summary>
					public String ShortCode{
						get{return response.GetString("shortCode");}
					}
			/// <summary>
			/// The size of the item in bytes
			/// </summary>
					public long? Size{
						get{return response.GetLong("size");}
					}
			/// <summary>
			/// The download URL
			/// </summary>
					public String Url{
						get{return response.GetString("url");}
					}
	}
	
	
	public class GetLeaderboardEntriesResponse : GSTypedResponse
	{
		public GetLeaderboardEntriesResponse(GSData data) : base(data){}
	}
	
	
	public class GetMessageResponse : GSTypedResponse
	{
		public GetMessageResponse(GSData data) : base(data){}
			/// <summary>
			/// The message data
			/// </summary>
					public GSData Message{
						get{return response.GetObject("message");}
					}
			/// <summary>
			/// The message status
			/// </summary>
					public String Status{
						get{return response.GetString("status");}
					}
	}
	
	
	public class GetMyTeamsResponse : GSTypedResponse
	{
		public GetMyTeamsResponse(GSData data) : base(data){}
		/// <summary>
		/// A nested object that represents the team.
		/// </summary>
		public class _Team : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Team(GSData data) : base(data){}
			
		/// <summary>
		/// A nested object that represents a player.
		/// </summary>
		public class _Player : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Player(GSData data) : base(data){}
			
			/// <summary>
			/// The achievements of the Player
			/// </summary>
						public List<String> Achievements{
							get{ return response.GetStringList("achievements");}
						}
			/// <summary>
			/// The display name of the Player
			/// </summary>
					public String DisplayName{
						get{return response.GetString("displayName");}
					}
			/// <summary>
			/// The external Id's of the Player
			/// </summary>
					public GSData ExternalIds{
						get{return response.GetObject("externalIds");}
					}
			/// <summary>
			/// The Id of the Player
			/// </summary>
					public String Id{
						get{return response.GetString("id");}
					}
			/// <summary>
			/// The online status of the Player
			/// </summary>
					public bool? Online{
						get{return response.GetBoolean("online");}
					}
			/// <summary>
			/// The virtual goods of the Player
			/// </summary>
						public List<String> VirtualGoods{
							get{ return response.GetStringList("virtualGoods");}
						}
			
			
		}
			/// <summary>
			/// The team members
			/// </summary>
					public GSEnumerable<_Player> Members{
						get{return new GSEnumerable<_Player>(response.GetObjectList("members"), (data) => { return new _Player(data);});}
					}
			/// <summary>
			/// A summary of the owner
			/// </summary>
					public _Player Owner{
						get{
							if(response.GetObject("owner") == null) { return null; }
							return new _Player(response.GetObject("owner"));
						}
					}
			/// <summary>
			/// The Id of the team
			/// </summary>
					public String TeamId{
						get{return response.GetString("teamId");}
					}
			/// <summary>
			/// The team name
			/// </summary>
					public String TeamName{
						get{return response.GetString("teamName");}
					}
			/// <summary>
			/// The team type
			/// </summary>
					public String TeamType{
						get{return response.GetString("teamType");}
					}
			
			
		}
			/// <summary>
			/// The team data
			/// </summary>
					public GSEnumerable<_Team> Teams{
						get{return new GSEnumerable<_Team>(response.GetObjectList("teams"), (data) => { return new _Team(data);});}
					}
	}
	
	
	public class GetPropertyResponse : GSTypedResponse
	{
		public GetPropertyResponse(GSData data) : base(data){}
			/// <summary>
			/// The property value
			/// </summary>
					public GSData Property{
						get{return response.GetObject("property");}
					}
	}
	
	
	public class GetPropertySetResponse : GSTypedResponse
	{
		public GetPropertySetResponse(GSData data) : base(data){}
			/// <summary>
			/// The property set
			/// </summary>
					public GSData PropertySet{
						get{return response.GetObject("propertySet");}
					}
	}
	
	
	public class GetTeamResponse : GSTypedResponse
	{
		public GetTeamResponse(GSData data) : base(data){}
		/// <summary>
		/// A nested object that represents the team.
		/// </summary>
		public class _Team : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Team(GSData data) : base(data){}
			
		/// <summary>
		/// A nested object that represents a player.
		/// </summary>
		public class _Player : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Player(GSData data) : base(data){}
			
			/// <summary>
			/// The achievements of the Player
			/// </summary>
						public List<String> Achievements{
							get{ return response.GetStringList("achievements");}
						}
			/// <summary>
			/// The display name of the Player
			/// </summary>
					public String DisplayName{
						get{return response.GetString("displayName");}
					}
			/// <summary>
			/// The external Id's of the Player
			/// </summary>
					public GSData ExternalIds{
						get{return response.GetObject("externalIds");}
					}
			/// <summary>
			/// The Id of the Player
			/// </summary>
					public String Id{
						get{return response.GetString("id");}
					}
			/// <summary>
			/// The online status of the Player
			/// </summary>
					public bool? Online{
						get{return response.GetBoolean("online");}
					}
			/// <summary>
			/// The virtual goods of the Player
			/// </summary>
						public List<String> VirtualGoods{
							get{ return response.GetStringList("virtualGoods");}
						}
			
			
		}
			/// <summary>
			/// The team members
			/// </summary>
					public GSEnumerable<_Player> Members{
						get{return new GSEnumerable<_Player>(response.GetObjectList("members"), (data) => { return new _Player(data);});}
					}
			/// <summary>
			/// A summary of the owner
			/// </summary>
					public _Player Owner{
						get{
							if(response.GetObject("owner") == null) { return null; }
							return new _Player(response.GetObject("owner"));
						}
					}
			/// <summary>
			/// The Id of the team
			/// </summary>
					public String TeamId{
						get{return response.GetString("teamId");}
					}
			/// <summary>
			/// The team name
			/// </summary>
					public String TeamName{
						get{return response.GetString("teamName");}
					}
			/// <summary>
			/// The team type
			/// </summary>
					public String TeamType{
						get{return response.GetString("teamType");}
					}
			
			
		}
		/// <summary>
		/// A nested object that represents a player.
		/// </summary>
		public class _Player : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Player(GSData data) : base(data){}
			
			/// <summary>
			/// The achievements of the Player
			/// </summary>
						public List<String> Achievements{
							get{ return response.GetStringList("achievements");}
						}
			/// <summary>
			/// The display name of the Player
			/// </summary>
					public String DisplayName{
						get{return response.GetString("displayName");}
					}
			/// <summary>
			/// The external Id's of the Player
			/// </summary>
					public GSData ExternalIds{
						get{return response.GetObject("externalIds");}
					}
			/// <summary>
			/// The Id of the Player
			/// </summary>
					public String Id{
						get{return response.GetString("id");}
					}
			/// <summary>
			/// The online status of the Player
			/// </summary>
					public bool? Online{
						get{return response.GetBoolean("online");}
					}
			/// <summary>
			/// The virtual goods of the Player
			/// </summary>
						public List<String> VirtualGoods{
							get{ return response.GetStringList("virtualGoods");}
						}
			
			
		}
			/// <summary>
			/// The team members
			/// </summary>
					public GSEnumerable<_Player> Members{
						get{return new GSEnumerable<_Player>(response.GetObjectList("members"), (data) => { return new _Player(data);});}
					}
			/// <summary>
			/// A summary of the owner
			/// </summary>
					public _Player Owner{
						get{
							if(response.GetObject("owner") == null) { return null; }
							return new _Player(response.GetObject("owner"));
						}
					}
			/// <summary>
			/// The Id of the team
			/// </summary>
					public String TeamId{
						get{return response.GetString("teamId");}
					}
			/// <summary>
			/// The team name
			/// </summary>
					public String TeamName{
						get{return response.GetString("teamName");}
					}
			/// <summary>
			/// The team type
			/// </summary>
					public String TeamType{
						get{return response.GetString("teamType");}
					}
			/// <summary>
			/// A JSON array of teams.
			/// </summary>
					public GSEnumerable<_Team> Teams{
						get{return new GSEnumerable<_Team>(response.GetObjectList("teams"), (data) => { return new _Team(data);});}
					}
	}
	
	
	public class GetUploadUrlResponse : GSTypedResponse
	{
		public GetUploadUrlResponse(GSData data) : base(data){}
			/// <summary>
			/// The time sensitive upload URL
			/// </summary>
					public String Url{
						get{return response.GetString("url");}
					}
	}
	
	
	public class GetUploadedResponse : GSTypedResponse
	{
		public GetUploadedResponse(GSData data) : base(data){}
			/// <summary>
			/// The size of the file in bytes
			/// </summary>
					public long? Size{
						get{return response.GetLong("size");}
					}
			/// <summary>
			/// A time sensitive URL to a piece of content
			/// </summary>
					public String Url{
						get{return response.GetString("url");}
					}
	}
	
	
	public class JoinChallengeResponse : GSTypedResponse
	{
		public JoinChallengeResponse(GSData data) : base(data){}
			/// <summary>
			/// Whether the player successfully joined the challenge
			/// </summary>
					public bool? Joined{
						get{return response.GetBoolean("joined");}
					}
	}
	
	
	public class JoinPendingMatchResponse : GSTypedResponse
	{
		public JoinPendingMatchResponse(GSData data) : base(data){}
		/// <summary>
		/// An object that represents a pending match.
		/// </summary>
		public class _PendingMatch : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _PendingMatch(GSData data) : base(data){}
			
		/// <summary>
		/// An object that represents a player in a pending match.
		/// </summary>
		public class _MatchedPlayer : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _MatchedPlayer(GSData data) : base(data){}
			
			/// <summary>
			/// The Location of the player
			/// </summary>
					public GSData Location{
						get{return response.GetObject("location");}
					}
			/// <summary>
			/// A JSON Map of any data that was associated to this user
			/// </summary>
					public GSData ParticipantData{
						get{return response.GetObject("participantData");}
					}
			/// <summary>
			/// The ID for player
			/// </summary>
					public String PlayerId{
						get{return response.GetString("playerId");}
					}
			/// <summary>
			/// The skill of the player in this match
			/// </summary>
					public double? Skill{
						get{return response.GetDouble("skill");}
					}
			
			
		}
			/// <summary>
			/// The ID for the pending match
			/// </summary>
					public String Id{
						get{return response.GetString("id");}
					}
			/// <summary>
			/// A JSON Map of the matchData associated to this pending match
			/// </summary>
					public GSData MatchData{
						get{return response.GetObject("matchData");}
					}
			/// <summary>
			/// The match group for the pending match
			/// </summary>
					public String MatchGroup{
						get{return response.GetString("matchGroup");}
					}
			/// <summary>
			/// The match shortCode for the pending match
			/// </summary>
					public String MatchShortCode{
						get{return response.GetString("matchShortCode");}
					}
			/// <summary>
			/// The players already part of this pending match
			/// </summary>
					public GSEnumerable<_MatchedPlayer> MatchedPlayers{
						get{return new GSEnumerable<_MatchedPlayer>(response.GetObjectList("matchedPlayers"), (data) => { return new _MatchedPlayer(data);});}
					}
			/// <summary>
			/// The average skill of players in this pending match
			/// </summary>
					public double? Skill{
						get{return response.GetDouble("skill");}
					}
			
			
		}
			/// <summary>
			/// A JSON object containing the new pending match
			/// </summary>
					public _PendingMatch PendingMatch{
						get{
							if(response.GetObject("pendingMatch") == null) { return null; }
							return new _PendingMatch(response.GetObject("pendingMatch"));
						}
					}
	}
	
	
	public class JoinTeamResponse : GSTypedResponse
	{
		public JoinTeamResponse(GSData data) : base(data){}
		/// <summary>
		/// A nested object that represents a player.
		/// </summary>
		public class _Player : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Player(GSData data) : base(data){}
			
			/// <summary>
			/// The achievements of the Player
			/// </summary>
						public List<String> Achievements{
							get{ return response.GetStringList("achievements");}
						}
			/// <summary>
			/// The display name of the Player
			/// </summary>
					public String DisplayName{
						get{return response.GetString("displayName");}
					}
			/// <summary>
			/// The external Id's of the Player
			/// </summary>
					public GSData ExternalIds{
						get{return response.GetObject("externalIds");}
					}
			/// <summary>
			/// The Id of the Player
			/// </summary>
					public String Id{
						get{return response.GetString("id");}
					}
			/// <summary>
			/// The online status of the Player
			/// </summary>
					public bool? Online{
						get{return response.GetBoolean("online");}
					}
			/// <summary>
			/// The virtual goods of the Player
			/// </summary>
						public List<String> VirtualGoods{
							get{ return response.GetStringList("virtualGoods");}
						}
			
			
		}
			/// <summary>
			/// The team members
			/// </summary>
					public GSEnumerable<_Player> Members{
						get{return new GSEnumerable<_Player>(response.GetObjectList("members"), (data) => { return new _Player(data);});}
					}
			/// <summary>
			/// A summary of the owner
			/// </summary>
					public _Player Owner{
						get{
							if(response.GetObject("owner") == null) { return null; }
							return new _Player(response.GetObject("owner"));
						}
					}
			/// <summary>
			/// The Id of the team
			/// </summary>
					public String TeamId{
						get{return response.GetString("teamId");}
					}
			/// <summary>
			/// The team name
			/// </summary>
					public String TeamName{
						get{return response.GetString("teamName");}
					}
			/// <summary>
			/// The team type
			/// </summary>
					public String TeamType{
						get{return response.GetString("teamType");}
					}
	}
	
	
	public class LeaderboardDataResponse : GSTypedResponse
	{
		public LeaderboardDataResponse(GSData data) : base(data){}
		/// <summary>
		/// Leaderboard entry data
		/// As well as the parameters below there may be others depending on your game's configuration.
		/// </summary>
		public class _LeaderboardData : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _LeaderboardData(GSData data) : base(data){}
			
			/// <summary>
			/// The city where the player was located when they logged this leaderboard entry.
			/// </summary>
					public String City{
						get{return response.GetString("city");}
					}
			/// <summary>
			/// The country code where the player was located when they logged this leaderboard entry.
			/// </summary>
					public String Country{
						get{return response.GetString("country");}
					}
			/// <summary>
			/// The players rank.
			/// </summary>
					public GSData ExternalIds{
						get{return response.GetObject("externalIds");}
					}
			/// <summary>
			/// The players rank.
			/// </summary>
					public long? Rank{
						get{return response.GetLong("rank");}
					}
			/// <summary>
			/// The unique player id for this leaderboard entry.
			/// </summary>
					public String UserId{
						get{return response.GetString("userId");}
					}
			/// <summary>
			/// The players display name.
			/// </summary>
					public String UserName{
						get{return response.GetString("userName");}
					}
			/// <summary>
			/// The date when this leaderboard entry was created.
			/// </summary>
					public String When{
						get{return response.GetString("when");}
					}
			
			public long? GetNumberValue(String key){
				return response.GetLong(key);
			}
			
			public string GetStringValue(String key){
				return response.GetString(key);
			}
			
		}
			/// <summary>
			/// The leaderboard's challenge id
			/// </summary>
					public String ChallengeInstanceId{
						get{return response.GetString("challengeInstanceId");}
					}
			/// <summary>
			/// The leaderboard data
			/// </summary>
					public GSEnumerable<_LeaderboardData> Data{
						get{return new GSEnumerable<_LeaderboardData>(response.GetObjectList("data"), (data) => { return new _LeaderboardData(data);});}
					}
			/// <summary>
			/// The first item in the leaderboard data
			/// </summary>
					public GSEnumerable<_LeaderboardData> First{
						get{return new GSEnumerable<_LeaderboardData>(response.GetObjectList("first"), (data) => { return new _LeaderboardData(data);});}
					}
			/// <summary>
			/// The last item in the leaderboard data
			/// </summary>
					public GSEnumerable<_LeaderboardData> Last{
						get{return new GSEnumerable<_LeaderboardData>(response.GetObjectList("last"), (data) => { return new _LeaderboardData(data);});}
					}
			/// <summary>
			/// The leaderboard short code
			/// </summary>
					public String LeaderboardShortCode{
						get{return response.GetString("leaderboardShortCode");}
					}
	}
	
	
	public class LeaderboardsEntriesResponse : GSTypedResponse
	{
		public LeaderboardsEntriesResponse(GSData data) : base(data){}
	}
	
	
	public class LeaveTeamResponse : GSTypedResponse
	{
		public LeaveTeamResponse(GSData data) : base(data){}
		/// <summary>
		/// A nested object that represents a player.
		/// </summary>
		public class _Player : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Player(GSData data) : base(data){}
			
			/// <summary>
			/// The achievements of the Player
			/// </summary>
						public List<String> Achievements{
							get{ return response.GetStringList("achievements");}
						}
			/// <summary>
			/// The display name of the Player
			/// </summary>
					public String DisplayName{
						get{return response.GetString("displayName");}
					}
			/// <summary>
			/// The external Id's of the Player
			/// </summary>
					public GSData ExternalIds{
						get{return response.GetObject("externalIds");}
					}
			/// <summary>
			/// The Id of the Player
			/// </summary>
					public String Id{
						get{return response.GetString("id");}
					}
			/// <summary>
			/// The online status of the Player
			/// </summary>
					public bool? Online{
						get{return response.GetBoolean("online");}
					}
			/// <summary>
			/// The virtual goods of the Player
			/// </summary>
						public List<String> VirtualGoods{
							get{ return response.GetStringList("virtualGoods");}
						}
			
			
		}
			/// <summary>
			/// The team members
			/// </summary>
					public GSEnumerable<_Player> Members{
						get{return new GSEnumerable<_Player>(response.GetObjectList("members"), (data) => { return new _Player(data);});}
					}
			/// <summary>
			/// A summary of the owner
			/// </summary>
					public _Player Owner{
						get{
							if(response.GetObject("owner") == null) { return null; }
							return new _Player(response.GetObject("owner"));
						}
					}
			/// <summary>
			/// The Id of the team
			/// </summary>
					public String TeamId{
						get{return response.GetString("teamId");}
					}
			/// <summary>
			/// The team name
			/// </summary>
					public String TeamName{
						get{return response.GetString("teamName");}
					}
			/// <summary>
			/// The team type
			/// </summary>
					public String TeamType{
						get{return response.GetString("teamType");}
					}
	}
	
	
	public class ListAchievementsResponse : GSTypedResponse
	{
		public ListAchievementsResponse(GSData data) : base(data){}
		/// <summary>
		/// A nested object that represents the achievement data.
		/// </summary>
		public class _Achievement : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Achievement(GSData data) : base(data){}
			
			/// <summary>
			/// The desciption of the Achievement
			/// </summary>
					public String Description{
						get{return response.GetString("description");}
					}
			/// <summary>
			/// Whether to current player has earned the achievement
			/// </summary>
					public bool? Earned{
						get{return response.GetBoolean("earned");}
					}
			/// <summary>
			/// The name of the Achievement
			/// </summary>
					public String Name{
						get{return response.GetString("name");}
					}
			/// <summary>
			/// The custom property set configured on this Achievement
			/// </summary>
					public GSData PropertySet{
						get{return response.GetObject("propertySet");}
					}
			/// <summary>
			/// The shortCode of the Achievement
			/// </summary>
					public String ShortCode{
						get{return response.GetString("shortCode");}
					}
			
			
		}
			/// <summary>
			/// A list of JSON achievment objects
			/// </summary>
					public GSEnumerable<_Achievement> Achievements{
						get{return new GSEnumerable<_Achievement>(response.GetObjectList("achievements"), (data) => { return new _Achievement(data);});}
					}
	}
	
	
	public class ListBulkJobsAdminResponse : GSTypedResponse
	{
		public ListBulkJobsAdminResponse(GSData data) : base(data){}
		/// <summary>
		/// A nested object that represents the bulk job.
		/// </summary>
		public class _BulkJob : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _BulkJob(GSData data) : base(data){}
			
			/// <summary>
			/// The actual count of players affected by the bulk job (calculated when the job started to run)
			/// </summary>
					public long? ActualCount{
						get{return response.GetLong("actualCount");}
					}
			/// <summary>
			/// The time at which the bulk job completed execution
			/// </summary>
					public DateTime? Completed{
						get{return response.GetDate("completed");}
					}
			/// <summary>
			/// The time at which the bulk job was created
			/// </summary>
					public DateTime? Created{
						get{return response.GetDate("created");}
					}
			/// <summary>
			/// Data to be passed into the Module or Script
			/// </summary>
					public GSData Data{
						get{return response.GetObject("data");}
					}
			/// <summary>
			/// The number of players processed by the bulk job so far
			/// </summary>
					public long? DoneCount{
						get{return response.GetLong("doneCount");}
					}
			/// <summary>
			/// The number of errors encountered whilst running the Module or Script for players
			/// </summary>
					public long? ErrorCount{
						get{return response.GetLong("errorCount");}
					}
			/// <summary>
			/// The estimated count of players affected by the bulk job (estimated when the job was submitted)
			/// </summary>
					public long? EstimatedCount{
						get{return response.GetLong("estimatedCount");}
					}
			/// <summary>
			/// The ID for the bulk job
			/// </summary>
					public String Id{
						get{return response.GetString("id");}
					}
			/// <summary>
			/// The Cloud Code Module to run for each player
			/// </summary>
					public String ModuleShortCode{
						get{return response.GetString("moduleShortCode");}
					}
			/// <summary>
			/// The query to identify players to perform the bulk job on
			/// </summary>
					public GSData PlayerQuery{
						get{return response.GetObject("playerQuery");}
					}
			/// <summary>
			/// The time at which the job was scheduled to run
			/// </summary>
					public DateTime? ScheduledTime{
						get{return response.GetDate("scheduledTime");}
					}
			/// <summary>
			/// The Cloud Code script to run for each player
			/// </summary>
					public String Script{
						get{return response.GetString("script");}
					}
			/// <summary>
			/// The time at which the bulk job started to execute
			/// </summary>
					public DateTime? Started{
						get{return response.GetDate("started");}
					}
			/// <summary>
			/// The current state of the bulk job
			/// </summary>
					public String State{
						get{return response.GetString("state");}
					}
			
			
		}
			/// <summary>
			/// A list of JSON objects containing bulk jobs
			/// </summary>
					public GSEnumerable<_BulkJob> BulkJobs{
						get{return new GSEnumerable<_BulkJob>(response.GetObjectList("bulkJobs"), (data) => { return new _BulkJob(data);});}
					}
	}
	
	
	public class ListChallengeResponse : GSTypedResponse
	{
		public ListChallengeResponse(GSData data) : base(data){}
		/// <summary>
		/// A nested object that represents the challenge data.
		/// </summary>
		public class _Challenge : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Challenge(GSData data) : base(data){}
			
		/// <summary>
		/// An object representing a player's id and name
		/// </summary>
		public class _PlayerDetail : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _PlayerDetail(GSData data) : base(data){}
			
			/// <summary>
			/// A player's external identifiers
			/// </summary>
					public GSData ExternalIds{
						get{return response.GetObject("externalIds");}
					}
			/// <summary>
			/// A player's id
			/// </summary>
					public String Id{
						get{return response.GetString("id");}
					}
			/// <summary>
			/// A player's name
			/// </summary>
					public String Name{
						get{return response.GetString("name");}
					}
			
			
		}
		/// <summary>
		/// Represents the number of turns a player has taken in a turn based challenge.
		/// </summary>
		public class _PlayerTurnCount : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _PlayerTurnCount(GSData data) : base(data){}
			
			/// <summary>
			/// The number of turns that the player has taken so far during this challenge.
			/// </summary>
					public String Count{
						get{return response.GetString("count");}
					}
			/// <summary>
			/// The unique player id.
			/// </summary>
					public String PlayerId{
						get{return response.GetString("playerId");}
					}
			
			
		}
			/// <summary>
			/// A list of PlayerDetail objects that represents the players that have accepted this challenge.
			/// </summary>
					public GSEnumerable<_PlayerDetail> Accepted{
						get{return new GSEnumerable<_PlayerDetail>(response.GetObjectList("accepted"), (data) => { return new _PlayerDetail(data);});}
					}
			/// <summary>
			/// A unique identifier for this challenge.
			/// </summary>
					public String ChallengeId{
						get{return response.GetString("challengeId");}
					}
			/// <summary>
			/// The message included in the challenge by the challenging player who created the challenge.
			/// </summary>
					public String ChallengeMessage{
						get{return response.GetString("challengeMessage");}
					}
			/// <summary>
			/// The name of the challenge that this message relates to.
			/// </summary>
					public String ChallengeName{
						get{return response.GetString("challengeName");}
					}
			/// <summary>
			/// A list of PlayerDetail objects that represents the players that were challenged in this challenge.
			/// </summary>
					public GSEnumerable<_PlayerDetail> Challenged{
						get{return new GSEnumerable<_PlayerDetail>(response.GetObjectList("challenged"), (data) => { return new _PlayerDetail(data);});}
					}
			/// <summary>
			/// Details of the player who issued this challenge.
			/// </summary>
					public _PlayerDetail Challenger{
						get{
							if(response.GetObject("challenger") == null) { return null; }
							return new _PlayerDetail(response.GetObject("challenger"));
						}
					}
			/// <summary>
			/// The amount of type 1 currency that has been wagered on this challenge.
			/// </summary>
					public long? Currency1Wager{
						get{return response.GetLong("currency1Wager");}
					}
			/// <summary>
			/// The amount of type 2 currency that has been wagered on this challenge.
			/// </summary>
					public long? Currency2Wager{
						get{return response.GetLong("currency2Wager");}
					}
			/// <summary>
			/// The amount of type 3 currency that has been wagered on this challenge.
			/// </summary>
					public long? Currency3Wager{
						get{return response.GetLong("currency3Wager");}
					}
			/// <summary>
			/// The amount of type 4 currency that has been wagered on this challenge.
			/// </summary>
					public long? Currency4Wager{
						get{return response.GetLong("currency4Wager");}
					}
			/// <summary>
			/// The amount of type 5 currency that has been wagered on this challenge.
			/// </summary>
					public long? Currency5Wager{
						get{return response.GetLong("currency5Wager");}
					}
			/// <summary>
			/// The amount of type 6 currency that has been wagered on this challenge.
			/// </summary>
					public long? Currency6Wager{
						get{return response.GetLong("currency6Wager");}
					}
			/// <summary>
			/// An object representing the currencies that have been wagered on this challenge.
			/// </summary>
					public GSData CurrencyWagers{
						get{return response.GetObject("currencyWagers");}
					}
			/// <summary>
			/// A list of PlayerDetail objects that represents the players that have declined this challenge.
			/// </summary>
					public GSEnumerable<_PlayerDetail> Declined{
						get{return new GSEnumerable<_PlayerDetail>(response.GetObjectList("declined"), (data) => { return new _PlayerDetail(data);});}
					}
			/// <summary>
			/// The date when the challenge ends.
			/// </summary>
					public DateTime? EndDate{
						get{return response.GetDate("endDate");}
					}
			/// <summary>
			/// The latest date that a player can accept the challenge.
			/// </summary>
					public DateTime? ExpiryDate{
						get{return response.GetDate("expiryDate");}
					}
			/// <summary>
			/// The maximum number of turns that this challenge is configured for.
			/// </summary>
					public long? MaxTurns{
						get{return response.GetLong("maxTurns");}
					}
			/// <summary>
			/// In a turn based challenge this fields contains the player's id whose turn it is next.
			/// </summary>
					public String NextPlayer{
						get{return response.GetString("nextPlayer");}
					}
			/// <summary>
			/// The challenge's short code.
			/// </summary>
					public String ShortCode{
						get{return response.GetString("shortCode");}
					}
			/// <summary>
			/// The date when the challenge starts.
			/// </summary>
					public DateTime? StartDate{
						get{return response.GetDate("startDate");}
					}
			/// <summary>
			/// One of these possible state values: ISSUED, EXPIRED, ACCEPTED, DECLINED, COMPLETE, WITHDRAWN, RUNNING, WAITING, RECEIVED
			/// </summary>
					public String State{
						get{return response.GetString("state");}
					}
			/// <summary>
			/// A collection containing the number of turns taken by each player that has accepted the challenge.
			/// Each turn count is a Long keyed on a String that represents the player's id
			/// </summary>
					public GSEnumerable<_PlayerTurnCount> TurnCount{
						get{return new GSEnumerable<_PlayerTurnCount>(response.GetObjectList("turnCount"), (data) => { return new _PlayerTurnCount(data);});}
					}
			
			
		}
			/// <summary>
			/// A list of JSON objects representing the challenges.
			/// </summary>
					public GSEnumerable<_Challenge> ChallengeInstances{
						get{return new GSEnumerable<_Challenge>(response.GetObjectList("challengeInstances"), (data) => { return new _Challenge(data);});}
					}
	}
	
	
	public class ListChallengeTypeResponse : GSTypedResponse
	{
		public ListChallengeTypeResponse(GSData data) : base(data){}
		/// <summary>
		/// 
		/// </summary>
		public class _ChallengeType : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _ChallengeType(GSData data) : base(data){}
			
			/// <summary>
			/// The shortCode for this challenge.
			/// </summary>
					public String ChallengeShortCode{
						get{return response.GetString("challengeShortCode");}
					}
			/// <summary>
			/// The description of this challenge.
			/// </summary>
					public String Description{
						get{return response.GetString("description");}
					}
			/// <summary>
			/// The name of the leaderboard for this challenge.
			/// </summary>
					public String GetleaderboardName{
						get{return response.GetString("getleaderboardName");}
					}
			/// <summary>
			/// The name of this challenge.
			/// </summary>
					public String Name{
						get{return response.GetString("name");}
					}
			/// <summary>
			/// The tags for this challenge.
			/// </summary>
					public String Tags{
						get{return response.GetString("tags");}
					}
			
			
		}
			/// <summary>
			/// A list of JSON objects containing the challenge templates for the game
			/// </summary>
					public GSEnumerable<_ChallengeType> ChallengeTemplates{
						get{return new GSEnumerable<_ChallengeType>(response.GetObjectList("challengeTemplates"), (data) => { return new _ChallengeType(data);});}
					}
	}
	
	
	public class ListGameFriendsResponse : GSTypedResponse
	{
		public ListGameFriendsResponse(GSData data) : base(data){}
		/// <summary>
		/// A nested object that represents a player.
		/// </summary>
		public class _Player : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Player(GSData data) : base(data){}
			
			/// <summary>
			/// The achievements of the Player
			/// </summary>
						public List<String> Achievements{
							get{ return response.GetStringList("achievements");}
						}
			/// <summary>
			/// The display name of the Player
			/// </summary>
					public String DisplayName{
						get{return response.GetString("displayName");}
					}
			/// <summary>
			/// The external Id's of the Player
			/// </summary>
					public GSData ExternalIds{
						get{return response.GetObject("externalIds");}
					}
			/// <summary>
			/// The Id of the Player
			/// </summary>
					public String Id{
						get{return response.GetString("id");}
					}
			/// <summary>
			/// The online status of the Player
			/// </summary>
					public bool? Online{
						get{return response.GetBoolean("online");}
					}
			/// <summary>
			/// The virtual goods of the Player
			/// </summary>
						public List<String> VirtualGoods{
							get{ return response.GetStringList("virtualGoods");}
						}
			
			
		}
			/// <summary>
			/// A list of JSON objects containing game friend data
			/// </summary>
					public GSEnumerable<_Player> Friends{
						get{return new GSEnumerable<_Player>(response.GetObjectList("friends"), (data) => { return new _Player(data);});}
					}
	}
	
	
	public class ListInviteFriendsResponse : GSTypedResponse
	{
		public ListInviteFriendsResponse(GSData data) : base(data){}
		/// <summary>
		/// A nested object that represents the invitable friend.
		/// </summary>
		public class _InvitableFriend : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _InvitableFriend(GSData data) : base(data){}
			
			/// <summary>
			/// The display name of the External Friend
			/// </summary>
					public String DisplayName{
						get{return response.GetString("displayName");}
					}
			/// <summary>
			/// The ID of the External Friend
			/// </summary>
					public String Id{
						get{return response.GetString("id");}
					}
			/// <summary>
			/// The profile picture URL of the External Friend
			/// </summary>
					public String ProfilePic{
						get{return response.GetString("profilePic");}
					}
			
			
		}
			/// <summary>
			/// A list of JSON objects containing game friend data
			/// </summary>
					public GSEnumerable<_InvitableFriend> Friends{
						get{return new GSEnumerable<_InvitableFriend>(response.GetObjectList("friends"), (data) => { return new _InvitableFriend(data);});}
					}
	}
	
	
	public class ListLeaderboardsResponse : GSTypedResponse
	{
		public ListLeaderboardsResponse(GSData data) : base(data){}
		/// <summary>
		/// A nested object that represents the leaderboard configuration data.
		/// </summary>
		public class _Leaderboard : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Leaderboard(GSData data) : base(data){}
			
			/// <summary>
			/// The leaderboard's description.
			/// </summary>
					public String Description{
						get{return response.GetString("description");}
					}
			/// <summary>
			/// The leaderboard's name.
			/// </summary>
					public String Name{
						get{return response.GetString("name");}
					}
			/// <summary>
			/// The custom property set configured on this Leaderboard
			/// </summary>
					public GSData PropertySet{
						get{return response.GetObject("propertySet");}
					}
			/// <summary>
			/// The leaderboard's short code.
			/// </summary>
					public String ShortCode{
						get{return response.GetString("shortCode");}
					}
			
			
		}
			/// <summary>
			/// A list of JSON object containing leaderboard meta data
			/// </summary>
					public GSEnumerable<_Leaderboard> Leaderboards{
						get{return new GSEnumerable<_Leaderboard>(response.GetObjectList("leaderboards"), (data) => { return new _Leaderboard(data);});}
					}
	}
	
	
	public class ListMessageDetailResponse : GSTypedResponse
	{
		public ListMessageDetailResponse(GSData data) : base(data){}
		/// <summary>
		/// A nested object that represents a player message.
		/// </summary>
		public class _PlayerMessage : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _PlayerMessage(GSData data) : base(data){}
			
			/// <summary>
			/// The id of the message
			/// </summary>
					public String Id{
						get{return response.GetString("id");}
					}
			/// <summary>
			/// The message content
			/// </summary>
					public GSData Message{
						get{return response.GetObject("message");}
					}
			/// <summary>
			/// Whether the message has been delivered to the client
			/// </summary>
					public bool? Seen{
						get{return response.GetBoolean("seen");}
					}
			/// <summary>
			/// The status of the message
			/// </summary>
					public String Status{
						get{return response.GetString("status");}
					}
			/// <summary>
			/// The date of the message
			/// </summary>
					public DateTime? When{
						get{return response.GetDate("when");}
					}
			
			
		}
			/// <summary>
			/// A list of JSON objects containing player messages
			/// </summary>
					public GSEnumerable<_PlayerMessage> MessageList{
						get{return new GSEnumerable<_PlayerMessage>(response.GetObjectList("messageList"), (data) => { return new _PlayerMessage(data);});}
					}
	}
	
	
	public class ListMessageResponse : GSTypedResponse
	{
		public ListMessageResponse(GSData data) : base(data){}
			/// <summary>
			/// A list of JSON objects containing player messages
			/// </summary>
						public GSEnumerable<GSData> MessageList{
							
							get{return new GSEnumerable<GSData>(response.GetObjectList("messageList"), (data) => { return new GSData(data);});}
						}
	}
	
	
	public class ListMessageSummaryResponse : GSTypedResponse
	{
		public ListMessageSummaryResponse(GSData data) : base(data){}
			/// <summary>
			/// A list of JSON objects containing player message summaries
			/// </summary>
						public GSEnumerable<GSData> MessageList{
							
							get{return new GSEnumerable<GSData>(response.GetObjectList("messageList"), (data) => { return new GSData(data);});}
						}
	}
	
	
	public class ListTeamChatResponse : GSTypedResponse
	{
		public ListTeamChatResponse(GSData data) : base(data){}
		/// <summary>
		/// A message from a group chat
		/// </summary>
		public class _ChatMessage : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _ChatMessage(GSData data) : base(data){}
			
			/// <summary>
			/// The id of the player who sent this message
			/// </summary>
					public String FromId{
						get{return response.GetString("fromId");}
					}
			/// <summary>
			/// The id of this chat message
			/// </summary>
					public String Id{
						get{return response.GetString("id");}
					}
			/// <summary>
			/// The text sent in this message
			/// </summary>
					public String Message{
						get{return response.GetString("message");}
					}
			/// <summary>
			/// A date representing the time this message was sent
			/// </summary>
					public DateTime? When{
						get{return response.GetDate("when");}
					}
			/// <summary>
			/// The displayName of the player who sent this message
			/// </summary>
					public String Who{
						get{return response.GetString("who");}
					}
			
			
		}
			/// <summary>
			/// The collection of team chat messages
			/// </summary>
					public GSEnumerable<_ChatMessage> Messages{
						get{return new GSEnumerable<_ChatMessage>(response.GetObjectList("messages"), (data) => { return new _ChatMessage(data);});}
					}
	}
	
	
	public class ListTeamsResponse : GSTypedResponse
	{
		public ListTeamsResponse(GSData data) : base(data){}
		/// <summary>
		/// A nested object that represents the team. This object does not contain a list of the members.
		/// </summary>
		public class _Team : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Team(GSData data) : base(data){}
			
		/// <summary>
		/// A nested object that represents a player.
		/// </summary>
		public class _Player : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Player(GSData data) : base(data){}
			
			/// <summary>
			/// The achievements of the Player
			/// </summary>
						public List<String> Achievements{
							get{ return response.GetStringList("achievements");}
						}
			/// <summary>
			/// The display name of the Player
			/// </summary>
					public String DisplayName{
						get{return response.GetString("displayName");}
					}
			/// <summary>
			/// The external Id's of the Player
			/// </summary>
					public GSData ExternalIds{
						get{return response.GetObject("externalIds");}
					}
			/// <summary>
			/// The Id of the Player
			/// </summary>
					public String Id{
						get{return response.GetString("id");}
					}
			/// <summary>
			/// The online status of the Player
			/// </summary>
					public bool? Online{
						get{return response.GetBoolean("online");}
					}
			/// <summary>
			/// The virtual goods of the Player
			/// </summary>
						public List<String> VirtualGoods{
							get{ return response.GetStringList("virtualGoods");}
						}
			
			
		}
			/// <summary>
			/// A summary of the owner
			/// </summary>
					public _Player Owner{
						get{
							if(response.GetObject("owner") == null) { return null; }
							return new _Player(response.GetObject("owner"));
						}
					}
			/// <summary>
			/// The Id of the team
			/// </summary>
					public String TeamId{
						get{return response.GetString("teamId");}
					}
			/// <summary>
			/// The team name
			/// </summary>
					public String TeamName{
						get{return response.GetString("teamName");}
					}
			/// <summary>
			/// The team type
			/// </summary>
					public String TeamType{
						get{return response.GetString("teamType");}
					}
			
			
		}
			/// <summary>
			/// A list of JSON objects containing team information
			/// </summary>
					public GSEnumerable<_Team> Teams{
						get{return new GSEnumerable<_Team>(response.GetObjectList("teams"), (data) => { return new _Team(data);});}
					}
	}
	
	
	public class ListTransactionsResponse : GSTypedResponse
	{
		public ListTransactionsResponse(GSData data) : base(data){}
		/// <summary>
		/// A nested object that represents a player transaction.
		/// </summary>
		public class _PlayerTransaction : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _PlayerTransaction(GSData data) : base(data){}
			
		/// <summary>
		/// A nested object that represents a single item in a transaction.
		/// </summary>
		public class _PlayerTransactionItem : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _PlayerTransactionItem(GSData data) : base(data){}
			
			/// <summary>
			/// The amount of this item given to the player in the transaction
			/// </summary>
					public long? Amount{
						get{return response.GetLong("amount");}
					}
			/// <summary>
			/// The quantity the player possesses after the transaction completed
			/// </summary>
					public long? NewValue{
						get{return response.GetLong("newValue");}
					}
			/// <summary>
			/// The type of item
			/// </summary>
					public String Type{
						get{return response.GetString("type");}
					}
			
			
		}
			/// <summary>
			/// The items (currency or virtual goods) involved in this transaction
			/// </summary>
					public GSEnumerable<_PlayerTransactionItem> Items{
						get{return new GSEnumerable<_PlayerTransactionItem>(response.GetObjectList("items"), (data) => { return new _PlayerTransactionItem(data);});}
					}
			/// <summary>
			/// The original request ID for this transaction
			/// </summary>
					public String OriginalRequestId{
						get{return response.GetString("originalRequestId");}
					}
			/// <summary>
			/// The player ID
			/// </summary>
					public String PlayerId{
						get{return response.GetString("playerId");}
					}
			/// <summary>
			/// The reason for the transaction
			/// </summary>
					public String Reason{
						get{return response.GetString("reason");}
					}
			/// <summary>
			/// Gets the date when this transaction was revoked, if applicable
			/// </summary>
					public DateTime? RevokeDate{
						get{return response.GetDate("revokeDate");}
					}
			/// <summary>
			/// Is true if the transaction was revoked
			/// </summary>
					public bool? Revoked{
						get{return response.GetBoolean("revoked");}
					}
			/// <summary>
			/// The specific script in which this transaction occurred
			/// </summary>
					public String Script{
						get{return response.GetString("script");}
					}
			/// <summary>
			/// The script type in which this transaction occurred (e.g. event)
			/// </summary>
					public String ScriptType{
						get{return response.GetString("scriptType");}
					}
			/// <summary>
			/// The transaction ID of this purchase, if applicable
			/// </summary>
					public String TransactionId{
						get{return response.GetString("transactionId");}
					}
			/// <summary>
			/// The date of the transaction
			/// </summary>
					public DateTime? When{
						get{return response.GetDate("when");}
					}
			
			
		}
			/// <summary>
			/// A list of JSON objects containing player transactions
			/// </summary>
					public GSEnumerable<_PlayerTransaction> TransactionList{
						get{return new GSEnumerable<_PlayerTransaction>(response.GetObjectList("transactionList"), (data) => { return new _PlayerTransaction(data);});}
					}
	}
	
	
	public class ListVirtualGoodsResponse : GSTypedResponse
	{
		public ListVirtualGoodsResponse(GSData data) : base(data){}
		/// <summary>
		/// A nested object that represents the virtual good.
		/// </summary>
		public class _VirtualGood : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _VirtualGood(GSData data) : base(data){}
			
		/// <summary>
		/// A collection of arbitrary data that can be added to a message via a Cloud Code script.
		/// </summary>
		public class _BundledGood : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _BundledGood(GSData data) : base(data){}
			
			/// <summary>
			/// The number of items bundled
			/// </summary>
					public int? Qty{
						get{return response.GetInt("qty");}
					}
			/// <summary>
			/// The shortCode of the bundled good
			/// </summary>
					public String ShortCode{
						get{return response.GetString("shortCode");}
					}
			
			
		}
			/// <summary>
			/// The Windows Phone 8 productId of the item.
			/// </summary>
					public String WP8StoreProductId{
						get{return response.GetString("WP8StoreProductId");}
					}
			/// <summary>
			/// The Amazon Store productId of the item.
			/// </summary>
					public String AmazonStoreProductId{
						get{return response.GetString("amazonStoreProductId");}
					}
			/// <summary>
			/// The Base Currency1 cost of the Virtual Good, before segmentation
			/// </summary>
					public long? BaseCurrency1Cost{
						get{return response.GetLong("baseCurrency1Cost");}
					}
			/// <summary>
			/// The Base Currency2 cost of the Virtual Good, before segmentation
			/// </summary>
					public long? BaseCurrency2Cost{
						get{return response.GetLong("baseCurrency2Cost");}
					}
			/// <summary>
			/// The Base Currency3 cost of the Virtual Good, before segmentation
			/// </summary>
					public long? BaseCurrency3Cost{
						get{return response.GetLong("baseCurrency3Cost");}
					}
			/// <summary>
			/// The Base Currency4 cost of the Virtual Good, before segmentation
			/// </summary>
					public long? BaseCurrency4Cost{
						get{return response.GetLong("baseCurrency4Cost");}
					}
			/// <summary>
			/// The Base Currency5 cost of the Virtual Good, before segmentation
			/// </summary>
					public long? BaseCurrency5Cost{
						get{return response.GetLong("baseCurrency5Cost");}
					}
			/// <summary>
			/// The Base Currency6 cost of the Virtual Good, before segmentation
			/// </summary>
					public long? BaseCurrency6Cost{
						get{return response.GetLong("baseCurrency6Cost");}
					}
			/// <summary>
			/// The Base currency costs of the Virtual Good, before experiments
			/// </summary>
					public GSData BaseCurrencyCosts{
						get{return response.GetObject("baseCurrencyCosts");}
					}
			/// <summary>
			/// Returns the bundle goods of the virtual good
			/// </summary>
					public GSEnumerable<_BundledGood> BundledGoods{
						get{return new GSEnumerable<_BundledGood>(response.GetObjectList("bundledGoods"), (data) => { return new _BundledGood(data);});}
					}
			/// <summary>
			/// The Currency1 cost of the Virtual Good
			/// </summary>
					public long? Currency1Cost{
						get{return response.GetLong("currency1Cost");}
					}
			/// <summary>
			/// The Currency2 cost of the Virtual Good
			/// </summary>
					public long? Currency2Cost{
						get{return response.GetLong("currency2Cost");}
					}
			/// <summary>
			/// The Currency3 cost of the Virtual Good
			/// </summary>
					public long? Currency3Cost{
						get{return response.GetLong("currency3Cost");}
					}
			/// <summary>
			/// The Currency4 cost of the Virtual Good
			/// </summary>
					public long? Currency4Cost{
						get{return response.GetLong("currency4Cost");}
					}
			/// <summary>
			/// The Currency5 cost of the Virtual Good
			/// </summary>
					public long? Currency5Cost{
						get{return response.GetLong("currency5Cost");}
					}
			/// <summary>
			/// The Currency6 cost of the Virtual Good
			/// </summary>
					public long? Currency6Cost{
						get{return response.GetLong("currency6Cost");}
					}
			/// <summary>
			/// The currency costs of the Virtual Good
			/// </summary>
					public GSData CurrencyCosts{
						get{return response.GetObject("currencyCosts");}
					}
			/// <summary>
			/// The description of the Virtual Good
			/// </summary>
					public String Description{
						get{return response.GetString("description");}
					}
			/// <summary>
			/// Whether the item is disabled.
			/// </summary>
					public bool? Disabled{
						get{return response.GetBoolean("disabled");}
					}
			/// <summary>
			/// The google play productId of the item.
			/// </summary>
					public String GooglePlayProductId{
						get{return response.GetString("googlePlayProductId");}
					}
			/// <summary>
			/// The iOS AppStore productId of the item.
			/// </summary>
					public String IosAppStoreProductId{
						get{return response.GetString("iosAppStoreProductId");}
					}
			/// <summary>
			/// The maximum number of the Virtual Good that can be owned at one time
			/// </summary>
					public long? MaxQuantity{
						get{return response.GetLong("maxQuantity");}
					}
			/// <summary>
			/// The name of the Virtual Good
			/// </summary>
					public String Name{
						get{return response.GetString("name");}
					}
			/// <summary>
			/// The custom property set configured on the item.
			/// </summary>
					public GSData PropertySet{
						get{return response.GetObject("propertySet");}
					}
			/// <summary>
			/// The PSN Store productId of the item.
			/// </summary>
					public String PsnStoreProductId{
						get{return response.GetString("psnStoreProductId");}
					}
			/// <summary>
			/// The Segmented Currency1 cost of the Virtual Good, before experiments
			/// </summary>
					public long? SegmentedCurrency1Cost{
						get{return response.GetLong("segmentedCurrency1Cost");}
					}
			/// <summary>
			/// The Segmented Currency2 cost of the Virtual Good, before experiments
			/// </summary>
					public long? SegmentedCurrency2Cost{
						get{return response.GetLong("segmentedCurrency2Cost");}
					}
			/// <summary>
			/// The Segmented Currency3 cost of the Virtual Good, before experiments
			/// </summary>
					public long? SegmentedCurrency3Cost{
						get{return response.GetLong("segmentedCurrency3Cost");}
					}
			/// <summary>
			/// The Segmented Currency4 cost of the Virtual Good, before experiments
			/// </summary>
					public long? SegmentedCurrency4Cost{
						get{return response.GetLong("segmentedCurrency4Cost");}
					}
			/// <summary>
			/// The Segmented Currency5 cost of the Virtual Good, before experiments
			/// </summary>
					public long? SegmentedCurrency5Cost{
						get{return response.GetLong("segmentedCurrency5Cost");}
					}
			/// <summary>
			/// The Segmented Currency6 cost of the Virtual Good, before experiments
			/// </summary>
					public long? SegmentedCurrency6Cost{
						get{return response.GetLong("segmentedCurrency6Cost");}
					}
			/// <summary>
			/// The segmented currency costs of the Virtual Good, before experiments
			/// </summary>
					public GSData SegmentedCurrencyCosts{
						get{return response.GetObject("segmentedCurrencyCosts");}
					}
			/// <summary>
			/// The short code of the Virtual Good
			/// </summary>
					public String ShortCode{
						get{return response.GetString("shortCode");}
					}
			/// <summary>
			/// The Steam Store productId of the item.
			/// </summary>
					public String SteamStoreProductId{
						get{return response.GetString("steamStoreProductId");}
					}
			/// <summary>
			/// The tags of the Virtual Good
			/// </summary>
					public String Tags{
						get{return response.GetString("tags");}
					}
			/// <summary>
			/// The type of the virtual good, "VGOOD" or "CURRENCY"
			/// </summary>
					public String Type{
						get{return response.GetString("type");}
					}
			/// <summary>
			/// The Windows 8 productId of the item.
			/// </summary>
					public String W8StoreProductId{
						get{return response.GetString("w8StoreProductId");}
					}
			
			
		}
			/// <summary>
			/// A list of JSON objects containing virtual goods data
			/// </summary>
					public GSEnumerable<_VirtualGood> VirtualGoods{
						get{return new GSEnumerable<_VirtualGood>(response.GetObjectList("virtualGoods"), (data) => { return new _VirtualGood(data);});}
					}
	}
	
	
	public class LogChallengeEventResponse : GSTypedResponse
	{
		public LogChallengeEventResponse(GSData data) : base(data){}
	}
	
	
	public class LogEventResponse : GSTypedResponse
	{
		public LogEventResponse(GSData data) : base(data){}
	}
	
	
	public class MatchDetailsResponse : GSTypedResponse
	{
		public MatchDetailsResponse(GSData data) : base(data){}
		/// <summary>
		/// A nested object that represents a player.
		/// </summary>
		public class _Player : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Player(GSData data) : base(data){}
			
			/// <summary>
			/// The achievements of the Player
			/// </summary>
						public List<String> Achievements{
							get{ return response.GetStringList("achievements");}
						}
			/// <summary>
			/// The display name of the Player
			/// </summary>
					public String DisplayName{
						get{return response.GetString("displayName");}
					}
			/// <summary>
			/// The external Id's of the Player
			/// </summary>
					public GSData ExternalIds{
						get{return response.GetObject("externalIds");}
					}
			/// <summary>
			/// The Id of the Player
			/// </summary>
					public String Id{
						get{return response.GetString("id");}
					}
			/// <summary>
			/// The online status of the Player
			/// </summary>
					public bool? Online{
						get{return response.GetBoolean("online");}
					}
			/// <summary>
			/// The virtual goods of the Player
			/// </summary>
						public List<String> VirtualGoods{
							get{ return response.GetStringList("virtualGoods");}
						}
			
			
		}
			/// <summary>
			/// The accessToken used to authenticate this player for this match
			/// </summary>
					public String AccessToken{
						get{return response.GetString("accessToken");}
					}
			/// <summary>
			/// The host to connect to for this match
			/// </summary>
					public String Host{
						get{return response.GetString("host");}
					}
			/// <summary>
			/// MatchData is arbitrary data that can be stored in a Match instance by a Cloud Code script.
			/// </summary>
					public GSData MatchData{
						get{return response.GetObject("matchData");}
					}
			/// <summary>
			/// The id for this match instance
			/// </summary>
					public String MatchId{
						get{return response.GetString("matchId");}
					}
			/// <summary>
			/// The opponents this player has been matched against
			/// </summary>
					public GSEnumerable<_Player> Opponents{
						get{return new GSEnumerable<_Player>(response.GetObjectList("opponents"), (data) => { return new _Player(data);});}
					}
			/// <summary>
			/// The peerId of this player within the match
			/// </summary>
					public int? PeerId{
						get{return response.GetInt("peerId");}
					}
			/// <summary>
			/// The id of the current player
			/// </summary>
					public String PlayerId{
						get{return response.GetString("playerId");}
					}
			/// <summary>
			/// The port to connect to for this match
			/// </summary>
					public int? Port{
						get{return response.GetInt("port");}
					}
	}
	
	
	public class MatchmakingResponse : GSTypedResponse
	{
		public MatchmakingResponse(GSData data) : base(data){}
	}
	
	
	public class PushRegistrationResponse : GSTypedResponse
	{
		public PushRegistrationResponse(GSData data) : base(data){}
			/// <summary>
			/// An identifier for the successful registration.  Clients should store this value to be used in the event the player no longer wants to receive push notifications to this device.
			/// </summary>
					public String RegistrationId{
						get{return response.GetString("registrationId");}
					}
	}
	
	
	public class RegistrationResponse : GSTypedResponse
	{
		public RegistrationResponse(GSData data) : base(data){}
		/// <summary>
		/// A nested object that represents a player.
		/// </summary>
		public class _Player : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Player(GSData data) : base(data){}
			
			/// <summary>
			/// The achievements of the Player
			/// </summary>
						public List<String> Achievements{
							get{ return response.GetStringList("achievements");}
						}
			/// <summary>
			/// The display name of the Player
			/// </summary>
					public String DisplayName{
						get{return response.GetString("displayName");}
					}
			/// <summary>
			/// The external Id's of the Player
			/// </summary>
					public GSData ExternalIds{
						get{return response.GetObject("externalIds");}
					}
			/// <summary>
			/// The Id of the Player
			/// </summary>
					public String Id{
						get{return response.GetString("id");}
					}
			/// <summary>
			/// The online status of the Player
			/// </summary>
					public bool? Online{
						get{return response.GetBoolean("online");}
					}
			/// <summary>
			/// The virtual goods of the Player
			/// </summary>
						public List<String> VirtualGoods{
							get{ return response.GetStringList("virtualGoods");}
						}
			
			
		}
			/// <summary>
			/// 44b297a8-162a-4220-8c14-dad9a1946ad2
			/// </summary>
					public String AuthToken{
						get{return response.GetString("authToken");}
					}
			/// <summary>
			/// The player's display name
			/// </summary>
					public String DisplayName{
						get{return response.GetString("displayName");}
					}
			/// <summary>
			/// Indicates whether the player was created as part of this request
			/// </summary>
					public bool? NewPlayer{
						get{return response.GetBoolean("newPlayer");}
					}
			/// <summary>
			/// A summary of the player that would be switched to.  Only returned as part of an error response for a request where automatic switching is disabled.
			/// </summary>
					public _Player SwitchSummary{
						get{
							if(response.GetObject("switchSummary") == null) { return null; }
							return new _Player(response.GetObject("switchSummary"));
						}
					}
			/// <summary>
			/// The player's id
			/// </summary>
					public String UserId{
						get{return response.GetString("userId");}
					}
	}
	
	
	public class RevokePurchaseGoodsResponse : GSTypedResponse
	{
		public RevokePurchaseGoodsResponse(GSData data) : base(data){}
			/// <summary>
			/// The map of revoked goods
			/// </summary>
					public GSData RevokedGoods{
						get{return response.GetObject("revokedGoods");}
					}
	}
	
	
	public class ScheduleBulkJobAdminResponse : GSTypedResponse
	{
		public ScheduleBulkJobAdminResponse(GSData data) : base(data){}
			/// <summary>
			/// The count of players who would be affected by this job if it ran at the time it was submitted
			/// </summary>
					public long? EstimatedCount{
						get{return response.GetLong("estimatedCount");}
					}
			/// <summary>
			/// The unique job ID, used to identify this job in future requests
			/// </summary>
					public String JobId{
						get{return response.GetString("jobId");}
					}
	}
	
	
	public class SendFriendMessageResponse : GSTypedResponse
	{
		public SendFriendMessageResponse(GSData data) : base(data){}
	}
	
	
	public class SendTeamChatMessageResponse : GSTypedResponse
	{
		public SendTeamChatMessageResponse(GSData data) : base(data){}
	}
	
	
	public class SocialDisconnectResponse : GSTypedResponse
	{
		public SocialDisconnectResponse(GSData data) : base(data){}
	}
	
	
	public class SocialStatusResponse : GSTypedResponse
	{
		public SocialStatusResponse(GSData data) : base(data){}
		/// <summary>
		/// A the details of a social connection
		/// </summary>
		public class _SocialStatus : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _SocialStatus(GSData data) : base(data){}
			
			/// <summary>
			/// When the token is still active.
			/// </summary>
					public bool? Active{
						get{return response.GetBoolean("active");}
					}
			/// <summary>
			/// When the token expires (if available).
			/// </summary>
					public DateTime? Expires{
						get{return response.GetDate("expires");}
					}
			/// <summary>
			/// The identifier of the external platform.
			/// </summary>
					public String SystemId{
						get{return response.GetString("systemId");}
					}
			
			
		}
			/// <summary>
			/// A list of social statuses.
			/// </summary>
					public GSEnumerable<_SocialStatus> Statuses{
						get{return new GSEnumerable<_SocialStatus>(response.GetObjectList("statuses"), (data) => { return new _SocialStatus(data);});}
					}
	}
	
	
	public class UpdateMessageResponse : GSTypedResponse
	{
		public UpdateMessageResponse(GSData data) : base(data){}
	}
	
	
	public class WithdrawChallengeResponse : GSTypedResponse
	{
		public WithdrawChallengeResponse(GSData data) : base(data){}
			/// <summary>
			/// A challenge instance id
			/// </summary>
					public String ChallengeInstanceId{
						get{return response.GetString("challengeInstanceId");}
					}
	}
	
	
}

#pragma warning restore 612, 618