using System;
using System.Collections.Generic;
using GameSparks.Core;
using GameSparks.Api;

#pragma warning disable 612,618
#pragma warning disable 0114
#pragma warning disable 0108

//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!

namespace GameSparks.Api.Messages
{
	internal class GSAllMessageTypes
	{
		public static void RegisterAllMessageTypes()
		{
			AchievementEarnedMessage.RegisterMessageType();
			ChallengeAcceptedMessage.RegisterMessageType();
			ChallengeChangedMessage.RegisterMessageType();
			ChallengeChatMessage.RegisterMessageType();
			ChallengeDeclinedMessage.RegisterMessageType();
			ChallengeDrawnMessage.RegisterMessageType();
			ChallengeExpiredMessage.RegisterMessageType();
			ChallengeIssuedMessage.RegisterMessageType();
			ChallengeJoinedMessage.RegisterMessageType();
			ChallengeLapsedMessage.RegisterMessageType();
			ChallengeLostMessage.RegisterMessageType();
			ChallengeStartedMessage.RegisterMessageType();
			ChallengeTurnTakenMessage.RegisterMessageType();
			ChallengeWaitingMessage.RegisterMessageType();
			ChallengeWithdrawnMessage.RegisterMessageType();
			ChallengeWonMessage.RegisterMessageType();
			FriendMessage.RegisterMessageType();
			GlobalRankChangedMessage.RegisterMessageType();
			MatchFoundMessage.RegisterMessageType();
			MatchNotFoundMessage.RegisterMessageType();
			MatchUpdatedMessage.RegisterMessageType();
			NewHighScoreMessage.RegisterMessageType();
			NewTeamScoreMessage.RegisterMessageType();
			ScriptMessage.RegisterMessageType();
			SessionTerminatedMessage.RegisterMessageType();
			SocialRankChangedMessage.RegisterMessageType();
			TeamChatMessage.RegisterMessageType();
			TeamRankChangedMessage.RegisterMessageType();
			UploadCompleteMessage.RegisterMessageType();
		}
	}

	
	public class AchievementEarnedMessage : GSMessage
	{
		public AchievementEarnedMessage(GSData data) : base(data){}
		
		public static Action<AchievementEarnedMessage> Listener;

		private static AchievementEarnedMessage Create(GSData data)
		{
			AchievementEarnedMessage message = new AchievementEarnedMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".AchievementEarnedMessage"] = Create;
		}
		
			/// <summary>
			/// The name of achievement.
			/// </summary>
					public String AchievementName{
						get{return response.GetString("achievementName");}
					}
			/// <summary>
			/// The short code of the achievement.
			/// </summary>
					public String AchievementShortCode{
						get{return response.GetString("achievementShortCode");}
					}
			/// <summary>
			/// The amount of type 1 currency earned.
			/// </summary>
					public String Currency1Earned{
						get{return response.GetString("currency1Earned");}
					}
			/// <summary>
			/// The amount of type 2 currency earned.
			/// </summary>
					public String Currency2Earned{
						get{return response.GetString("currency2Earned");}
					}
			/// <summary>
			/// The amount of type 3 currency earned.
			/// </summary>
					public String Currency3Earned{
						get{return response.GetString("currency3Earned");}
					}
			/// <summary>
			/// The amount of type 4 currency earned.
			/// </summary>
					public String Currency4Earned{
						get{return response.GetString("currency4Earned");}
					}
			/// <summary>
			/// The amount of type 5 currency earned.
			/// </summary>
					public String Currency5Earned{
						get{return response.GetString("currency5Earned");}
					}
			/// <summary>
			/// The amount of type 6 currency earned.
			/// </summary>
					public String Currency6Earned{
						get{return response.GetString("currency6Earned");}
					}
			/// <summary>
			/// An object containing the short codes and amounts of the currencies credited to the player
			/// </summary>
					public GSData CurrencyAwards{
						get{return response.GetObject("currencyAwards");}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
			/// <summary>
			/// The name of the virtual good that was earned.
			/// </summary>
					public String VirtualGoodEarned{
						get{return response.GetString("virtualGoodEarned");}
					}
	}
	
	
	public class ChallengeAcceptedMessage : GSMessage
	{
		public ChallengeAcceptedMessage(GSData data) : base(data){}
		
		public static Action<ChallengeAcceptedMessage> Listener;

		private static ChallengeAcceptedMessage Create(GSData data)
		{
			ChallengeAcceptedMessage message = new ChallengeAcceptedMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".ChallengeAcceptedMessage"] = Create;
		}
		
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
			/// An object representing the challenge.
			/// </summary>
					public _Challenge Challenge{
						get{
							if(response.GetObject("challenge") == null) { return null; }
							return new _Challenge(response.GetObject("challenge"));
						}
					}
			/// <summary>
			/// A player message included in this message.
			/// </summary>
					public String Message{
						get{return response.GetString("message");}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
			/// <summary>
			/// The name of the player whose actions generated this message.
			/// </summary>
					public String Who{
						get{return response.GetString("who");}
					}
	}
	
	
	public class ChallengeChangedMessage : GSMessage
	{
		public ChallengeChangedMessage(GSData data) : base(data){}
		
		public static Action<ChallengeChangedMessage> Listener;

		private static ChallengeChangedMessage Create(GSData data)
		{
			ChallengeChangedMessage message = new ChallengeChangedMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".ChallengeChangedMessage"] = Create;
		}
		
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
			/// An object representing the challenge.
			/// </summary>
					public _Challenge Challenge{
						get{
							if(response.GetObject("challenge") == null) { return null; }
							return new _Challenge(response.GetObject("challenge"));
						}
					}
			/// <summary>
			/// The leaderboard data associated with this challenge.
			/// </summary>
					public _LeaderboardData LeaderboardData{
						get{
							if(response.GetObject("leaderboardData") == null) { return null; }
							return new _LeaderboardData(response.GetObject("leaderboardData"));
						}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
			/// <summary>
			/// Indicates which player has changed the challenge
			/// </summary>
					public String Who{
						get{return response.GetString("who");}
					}
	}
	
	
	public class ChallengeChatMessage : GSMessage
	{
		public ChallengeChatMessage(GSData data) : base(data){}
		
		public static Action<ChallengeChatMessage> Listener;

		private static ChallengeChatMessage Create(GSData data)
		{
			ChallengeChatMessage message = new ChallengeChatMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".ChallengeChatMessage"] = Create;
		}
		
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
			/// An object representing the challenge.
			/// </summary>
					public _Challenge Challenge{
						get{
							if(response.GetObject("challenge") == null) { return null; }
							return new _Challenge(response.GetObject("challenge"));
						}
					}
			/// <summary>
			/// A player message included in this message.
			/// </summary>
					public String Message{
						get{return response.GetString("message");}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
			/// <summary>
			/// The name of the player whose actions generated this message.
			/// </summary>
					public String Who{
						get{return response.GetString("who");}
					}
	}
	
	
	public class ChallengeDeclinedMessage : GSMessage
	{
		public ChallengeDeclinedMessage(GSData data) : base(data){}
		
		public static Action<ChallengeDeclinedMessage> Listener;

		private static ChallengeDeclinedMessage Create(GSData data)
		{
			ChallengeDeclinedMessage message = new ChallengeDeclinedMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".ChallengeDeclinedMessage"] = Create;
		}
		
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
			/// An object representing the challenge.
			/// </summary>
					public _Challenge Challenge{
						get{
							if(response.GetObject("challenge") == null) { return null; }
							return new _Challenge(response.GetObject("challenge"));
						}
					}
			/// <summary>
			/// A player message included in this message.
			/// </summary>
					public String Message{
						get{return response.GetString("message");}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
			/// <summary>
			/// The name of the player whose actions generated this message.
			/// </summary>
					public String Who{
						get{return response.GetString("who");}
					}
	}
	
	
	public class ChallengeDrawnMessage : GSMessage
	{
		public ChallengeDrawnMessage(GSData data) : base(data){}
		
		public static Action<ChallengeDrawnMessage> Listener;

		private static ChallengeDrawnMessage Create(GSData data)
		{
			ChallengeDrawnMessage message = new ChallengeDrawnMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".ChallengeDrawnMessage"] = Create;
		}
		
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
			/// An object representing the challenge.
			/// </summary>
					public _Challenge Challenge{
						get{
							if(response.GetObject("challenge") == null) { return null; }
							return new _Challenge(response.GetObject("challenge"));
						}
					}
			/// <summary>
			/// The leaderboard data associated with this challenge.
			/// </summary>
					public _LeaderboardData LeaderboardData{
						get{
							if(response.GetObject("leaderboardData") == null) { return null; }
							return new _LeaderboardData(response.GetObject("leaderboardData"));
						}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
	}
	
	
	public class ChallengeExpiredMessage : GSMessage
	{
		public ChallengeExpiredMessage(GSData data) : base(data){}
		
		public static Action<ChallengeExpiredMessage> Listener;

		private static ChallengeExpiredMessage Create(GSData data)
		{
			ChallengeExpiredMessage message = new ChallengeExpiredMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".ChallengeExpiredMessage"] = Create;
		}
		
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
			/// An object representing the challenge.
			/// </summary>
					public _Challenge Challenge{
						get{
							if(response.GetObject("challenge") == null) { return null; }
							return new _Challenge(response.GetObject("challenge"));
						}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
	}
	
	
	public class ChallengeIssuedMessage : GSMessage
	{
		public ChallengeIssuedMessage(GSData data) : base(data){}
		
		public static Action<ChallengeIssuedMessage> Listener;

		private static ChallengeIssuedMessage Create(GSData data)
		{
			ChallengeIssuedMessage message = new ChallengeIssuedMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".ChallengeIssuedMessage"] = Create;
		}
		
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
			/// An object representing the challenge.
			/// </summary>
					public _Challenge Challenge{
						get{
							if(response.GetObject("challenge") == null) { return null; }
							return new _Challenge(response.GetObject("challenge"));
						}
					}
			/// <summary>
			/// A player message included in this message.
			/// </summary>
					public String Message{
						get{return response.GetString("message");}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
			/// <summary>
			/// The name of the player whose actions generated this message.
			/// </summary>
					public String Who{
						get{return response.GetString("who");}
					}
	}
	
	
	public class ChallengeJoinedMessage : GSMessage
	{
		public ChallengeJoinedMessage(GSData data) : base(data){}
		
		public static Action<ChallengeJoinedMessage> Listener;

		private static ChallengeJoinedMessage Create(GSData data)
		{
			ChallengeJoinedMessage message = new ChallengeJoinedMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".ChallengeJoinedMessage"] = Create;
		}
		
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
			/// An object representing the challenge.
			/// </summary>
					public _Challenge Challenge{
						get{
							if(response.GetObject("challenge") == null) { return null; }
							return new _Challenge(response.GetObject("challenge"));
						}
					}
			/// <summary>
			/// A player message included in this message.
			/// </summary>
					public String Message{
						get{return response.GetString("message");}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
			/// <summary>
			/// The name of the player whose actions generated this message.
			/// </summary>
					public String Who{
						get{return response.GetString("who");}
					}
	}
	
	
	public class ChallengeLapsedMessage : GSMessage
	{
		public ChallengeLapsedMessage(GSData data) : base(data){}
		
		public static Action<ChallengeLapsedMessage> Listener;

		private static ChallengeLapsedMessage Create(GSData data)
		{
			ChallengeLapsedMessage message = new ChallengeLapsedMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".ChallengeLapsedMessage"] = Create;
		}
		
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
			/// An object representing the challenge.
			/// </summary>
					public _Challenge Challenge{
						get{
							if(response.GetObject("challenge") == null) { return null; }
							return new _Challenge(response.GetObject("challenge"));
						}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
	}
	
	
	public class ChallengeLostMessage : GSMessage
	{
		public ChallengeLostMessage(GSData data) : base(data){}
		
		public static Action<ChallengeLostMessage> Listener;

		private static ChallengeLostMessage Create(GSData data)
		{
			ChallengeLostMessage message = new ChallengeLostMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".ChallengeLostMessage"] = Create;
		}
		
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
			/// An object representing the challenge.
			/// </summary>
					public _Challenge Challenge{
						get{
							if(response.GetObject("challenge") == null) { return null; }
							return new _Challenge(response.GetObject("challenge"));
						}
					}
			/// <summary>
			/// The leaderboard data associated with this challenge.
			/// </summary>
					public _LeaderboardData LeaderboardData{
						get{
							if(response.GetObject("leaderboardData") == null) { return null; }
							return new _LeaderboardData(response.GetObject("leaderboardData"));
						}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
			/// <summary>
			/// The winning players name
			/// </summary>
					public String WinnerName{
						get{return response.GetString("winnerName");}
					}
	}
	
	
	public class ChallengeStartedMessage : GSMessage
	{
		public ChallengeStartedMessage(GSData data) : base(data){}
		
		public static Action<ChallengeStartedMessage> Listener;

		private static ChallengeStartedMessage Create(GSData data)
		{
			ChallengeStartedMessage message = new ChallengeStartedMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".ChallengeStartedMessage"] = Create;
		}
		
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
			/// An object representing the challenge.
			/// </summary>
					public _Challenge Challenge{
						get{
							if(response.GetObject("challenge") == null) { return null; }
							return new _Challenge(response.GetObject("challenge"));
						}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
	}
	
	
	public class ChallengeTurnTakenMessage : GSMessage
	{
		public ChallengeTurnTakenMessage(GSData data) : base(data){}
		
		public static Action<ChallengeTurnTakenMessage> Listener;

		private static ChallengeTurnTakenMessage Create(GSData data)
		{
			ChallengeTurnTakenMessage message = new ChallengeTurnTakenMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".ChallengeTurnTakenMessage"] = Create;
		}
		
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
			/// An object representing the challenge.
			/// </summary>
					public _Challenge Challenge{
						get{
							if(response.GetObject("challenge") == null) { return null; }
							return new _Challenge(response.GetObject("challenge"));
						}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
			/// <summary>
			/// The name of the player whoe has taken their turn.
			/// </summary>
					public String Who{
						get{return response.GetString("who");}
					}
	}
	
	
	public class ChallengeWaitingMessage : GSMessage
	{
		public ChallengeWaitingMessage(GSData data) : base(data){}
		
		public static Action<ChallengeWaitingMessage> Listener;

		private static ChallengeWaitingMessage Create(GSData data)
		{
			ChallengeWaitingMessage message = new ChallengeWaitingMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".ChallengeWaitingMessage"] = Create;
		}
		
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
			/// An object representing the challenge.
			/// </summary>
					public _Challenge Challenge{
						get{
							if(response.GetObject("challenge") == null) { return null; }
							return new _Challenge(response.GetObject("challenge"));
						}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
	}
	
	
	public class ChallengeWithdrawnMessage : GSMessage
	{
		public ChallengeWithdrawnMessage(GSData data) : base(data){}
		
		public static Action<ChallengeWithdrawnMessage> Listener;

		private static ChallengeWithdrawnMessage Create(GSData data)
		{
			ChallengeWithdrawnMessage message = new ChallengeWithdrawnMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".ChallengeWithdrawnMessage"] = Create;
		}
		
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
			/// An object representing the challenge.
			/// </summary>
					public _Challenge Challenge{
						get{
							if(response.GetObject("challenge") == null) { return null; }
							return new _Challenge(response.GetObject("challenge"));
						}
					}
			/// <summary>
			/// A player message included in this message.
			/// </summary>
					public String Message{
						get{return response.GetString("message");}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
			/// <summary>
			/// The name of the player whose actions generated this message.
			/// </summary>
					public String Who{
						get{return response.GetString("who");}
					}
	}
	
	
	public class ChallengeWonMessage : GSMessage
	{
		public ChallengeWonMessage(GSData data) : base(data){}
		
		public static Action<ChallengeWonMessage> Listener;

		private static ChallengeWonMessage Create(GSData data)
		{
			ChallengeWonMessage message = new ChallengeWonMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".ChallengeWonMessage"] = Create;
		}
		
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
			/// An object representing the challenge.
			/// </summary>
					public _Challenge Challenge{
						get{
							if(response.GetObject("challenge") == null) { return null; }
							return new _Challenge(response.GetObject("challenge"));
						}
					}
			/// <summary>
			/// The amount of type 1 currency the player has won.
			/// </summary>
					public long? Currency1Won{
						get{return response.GetLong("currency1Won");}
					}
			/// <summary>
			/// The amount of type 2 currency the player has won.
			/// </summary>
					public long? Currency2Won{
						get{return response.GetLong("currency2Won");}
					}
			/// <summary>
			/// The amount of type 3 currency the player has won.
			/// </summary>
					public long? Currency3Won{
						get{return response.GetLong("currency3Won");}
					}
			/// <summary>
			/// The amount of type 4 currency the player has won.
			/// </summary>
					public long? Currency4Won{
						get{return response.GetLong("currency4Won");}
					}
			/// <summary>
			/// The amount of type 5 currency the player has won.
			/// </summary>
					public long? Currency5Won{
						get{return response.GetLong("currency5Won");}
					}
			/// <summary>
			/// The amount of type 6 currency the player has won.
			/// </summary>
					public long? Currency6Won{
						get{return response.GetLong("currency6Won");}
					}
			/// <summary>
			/// An object containing the short codes and amounts of the currencies the player has won
			/// </summary>
					public GSData CurrencyWinnings{
						get{return response.GetObject("currencyWinnings");}
					}
			/// <summary>
			/// The leaderboard data associated with this challenge.
			/// </summary>
					public _LeaderboardData LeaderboardData{
						get{
							if(response.GetObject("leaderboardData") == null) { return null; }
							return new _LeaderboardData(response.GetObject("leaderboardData"));
						}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
			/// <summary>
			/// The winning player's name.
			/// </summary>
					public String WinnerName{
						get{return response.GetString("winnerName");}
					}
	}
	
	
	public class FriendMessage : GSMessage
	{
		public FriendMessage(GSData data) : base(data){}
		
		public static Action<FriendMessage> Listener;

		private static FriendMessage Create(GSData data)
		{
			FriendMessage message = new FriendMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".FriendMessage"] = Create;
		}
		
			/// <summary>
			/// The player's id who is sending the message.
			/// </summary>
					public String FromId{
						get{return response.GetString("fromId");}
					}
			/// <summary>
			/// The player's message.
			/// </summary>
					public String Message{
						get{return response.GetString("message");}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
			/// <summary>
			/// The name of the player who is sending the message.
			/// </summary>
					public String Who{
						get{return response.GetString("who");}
					}
	}
	
	
	public class GlobalRankChangedMessage : GSMessage
	{
		public GlobalRankChangedMessage(GSData data) : base(data){}
		
		public static Action<GlobalRankChangedMessage> Listener;

		private static GlobalRankChangedMessage Create(GSData data)
		{
			GlobalRankChangedMessage message = new GlobalRankChangedMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".GlobalRankChangedMessage"] = Create;
		}
		
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
			/// The game id that this message relates to.
			/// </summary>
					public long? GameId{
						get{return response.GetLong("gameId");}
					}
			/// <summary>
			/// The leaderboard's name.
			/// </summary>
					public String LeaderboardName{
						get{return response.GetString("leaderboardName");}
					}
			/// <summary>
			/// The leaderboard shortcode.
			/// </summary>
					public String LeaderboardShortCode{
						get{return response.GetString("leaderboardShortCode");}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// The score details of the player whose score the receiving player has passed.
			/// </summary>
					public _LeaderboardData Them{
						get{
							if(response.GetObject("them") == null) { return null; }
							return new _LeaderboardData(response.GetObject("them"));
						}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
			/// <summary>
			/// The score details of the receiving player.
			/// </summary>
					public _LeaderboardData You{
						get{
							if(response.GetObject("you") == null) { return null; }
							return new _LeaderboardData(response.GetObject("you"));
						}
					}
	}
	
	
	public class MatchFoundMessage : GSMessage
	{
		public MatchFoundMessage(GSData data) : base(data){}
		
		public static Action<MatchFoundMessage> Listener;

		private static MatchFoundMessage Create(GSData data)
		{
			MatchFoundMessage message = new MatchFoundMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".MatchFoundMessage"] = Create;
		}
		
		/// <summary>
		/// A nested object that represents a participant in a match.
		/// </summary>
		public class _Participant : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Participant(GSData data) : base(data){}
			
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
			/// A JSON Map of any data that was associated to this user
			/// </summary>
					public GSData ParticipantData{
						get{return response.GetObject("participantData");}
					}
			/// <summary>
			/// The peerId of this participant within the match
			/// </summary>
					public int? PeerId{
						get{return response.GetInt("peerId");}
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
			/// The arbitrary data that is stored on a match instance in the matchData field
			/// </summary>
					public GSData MatchData{
						get{return response.GetObject("matchData");}
					}
			/// <summary>
			/// The group the player was assigned in the matchmaking request
			/// </summary>
					public String MatchGroup{
						get{return response.GetString("matchGroup");}
					}
			/// <summary>
			/// The id for this match instance
			/// </summary>
					public String MatchId{
						get{return response.GetString("matchId");}
					}
			/// <summary>
			/// The shortCode of the match type this message for
			/// </summary>
					public String MatchShortCode{
						get{return response.GetString("matchShortCode");}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// The participants in this match
			/// </summary>
					public GSEnumerable<_Participant> Participants{
						get{return new GSEnumerable<_Participant>(response.GetObjectList("participants"), (data) => { return new _Participant(data);});}
					}
			/// <summary>
			/// The arbitrary data that is stored on a pendingMatch in the matchData field
			/// </summary>
					public GSData PendingMatchData{
						get{return response.GetObject("pendingMatchData");}
					}
			/// <summary>
			/// The port to connect to for this match
			/// </summary>
					public int? Port{
						get{return response.GetInt("port");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
	}
	
	
	public class MatchNotFoundMessage : GSMessage
	{
		public MatchNotFoundMessage(GSData data) : base(data){}
		
		public static Action<MatchNotFoundMessage> Listener;

		private static MatchNotFoundMessage Create(GSData data)
		{
			MatchNotFoundMessage message = new MatchNotFoundMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".MatchNotFoundMessage"] = Create;
		}
		
		/// <summary>
		/// A nested object that represents a participant in a match.
		/// </summary>
		public class _Participant : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Participant(GSData data) : base(data){}
			
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
			/// A JSON Map of any data that was associated to this user
			/// </summary>
					public GSData ParticipantData{
						get{return response.GetObject("participantData");}
					}
			/// <summary>
			/// The peerId of this participant within the match
			/// </summary>
					public int? PeerId{
						get{return response.GetInt("peerId");}
					}
			/// <summary>
			/// The virtual goods of the Player
			/// </summary>
						public List<String> VirtualGoods{
							get{ return response.GetStringList("virtualGoods");}
						}
			
			
		}
			/// <summary>
			/// The arbitrary data that is stored on a pendingMatch in the matchData field.
			/// </summary>
					public GSData MatchData{
						get{return response.GetObject("matchData");}
					}
			/// <summary>
			/// The group the player was assigned in the matchmaking request
			/// </summary>
					public String MatchGroup{
						get{return response.GetString("matchGroup");}
					}
			/// <summary>
			/// The shortCode of the match type this message for
			/// </summary>
					public String MatchShortCode{
						get{return response.GetString("matchShortCode");}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// A JSON Map of any data that was associated to this user
			/// </summary>
					public GSData ParticipantData{
						get{return response.GetObject("participantData");}
					}
			/// <summary>
			/// The participants in this match
			/// </summary>
					public GSEnumerable<_Participant> Participants{
						get{return new GSEnumerable<_Participant>(response.GetObjectList("participants"), (data) => { return new _Participant(data);});}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
	}
	
	
	public class MatchUpdatedMessage : GSMessage
	{
		public MatchUpdatedMessage(GSData data) : base(data){}
		
		public static Action<MatchUpdatedMessage> Listener;

		private static MatchUpdatedMessage Create(GSData data)
		{
			MatchUpdatedMessage message = new MatchUpdatedMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".MatchUpdatedMessage"] = Create;
		}
		
		/// <summary>
		/// A nested object that represents a participant in a match.
		/// </summary>
		public class _Participant : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _Participant(GSData data) : base(data){}
			
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
			/// A JSON Map of any data that was associated to this user
			/// </summary>
					public GSData ParticipantData{
						get{return response.GetObject("participantData");}
					}
			/// <summary>
			/// The peerId of this participant within the match
			/// </summary>
					public int? PeerId{
						get{return response.GetInt("peerId");}
					}
			/// <summary>
			/// The virtual goods of the Player
			/// </summary>
						public List<String> VirtualGoods{
							get{ return response.GetStringList("virtualGoods");}
						}
			
			
		}
			/// <summary>
			/// The players that joined this match
			/// </summary>
						public List<String> AddedPlayers{
							get{ return response.GetStringList("addedPlayers");}
						}
			/// <summary>
			/// The arbitrary data that is stored on a pendingMatch in the matchData field
			/// </summary>
					public GSData MatchData{
						get{return response.GetObject("matchData");}
					}
			/// <summary>
			/// The group the player was assigned in the matchmaking request
			/// </summary>
					public String MatchGroup{
						get{return response.GetString("matchGroup");}
					}
			/// <summary>
			/// The id for this match instance
			/// </summary>
					public String MatchId{
						get{return response.GetString("matchId");}
					}
			/// <summary>
			/// The shortCode of the match type this message for
			/// </summary>
					public String MatchShortCode{
						get{return response.GetString("matchShortCode");}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// The participants in this match
			/// </summary>
					public GSEnumerable<_Participant> Participants{
						get{return new GSEnumerable<_Participant>(response.GetObjectList("participants"), (data) => { return new _Participant(data);});}
					}
			/// <summary>
			/// The players that left this match
			/// </summary>
						public List<String> RemovedPlayers{
							get{ return response.GetStringList("removedPlayers");}
						}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
	}
	
	
	public class NewHighScoreMessage : GSMessage
	{
		public NewHighScoreMessage(GSData data) : base(data){}
		
		public static Action<NewHighScoreMessage> Listener;

		private static NewHighScoreMessage Create(GSData data)
		{
			NewHighScoreMessage message = new NewHighScoreMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".NewHighScoreMessage"] = Create;
		}
		
		/// <summary>
		/// Ranking information.
		/// </summary>
		public class _LeaderboardRankDetails : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _LeaderboardRankDetails(GSData data) : base(data){}
			
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
			/// The leaderboard entries of the players friends that were beaten as part of this score submission.
			/// </summary>
					public GSEnumerable<_LeaderboardData> FriendsPassed{
						get{return new GSEnumerable<_LeaderboardData>(response.GetObjectList("friendsPassed"), (data) => { return new _LeaderboardData(data);});}
					}
			/// <summary>
			/// The number of entries in this leaderboard.
			/// </summary>
					public long? GlobalCount{
						get{return response.GetLong("globalCount");}
					}
			/// <summary>
			/// The Global Rank of the player in this leaderboard before the score was submitted.
			/// </summary>
					public long? GlobalFrom{
						get{return response.GetLong("globalFrom");}
					}
			/// <summary>
			/// The old global rank of the player as a percentage of the total number of scores in this leaderboard .
			/// </summary>
					public long? GlobalFromPercent{
						get{return response.GetLong("globalFromPercent");}
					}
			/// <summary>
			/// The Global Rank of the player in this leaderboard after the score was submitted.
			/// </summary>
					public long? GlobalTo{
						get{return response.GetLong("globalTo");}
					}
			/// <summary>
			/// The new global rank of the player as a percentage of the total number of scores in this leaderboard .
			/// </summary>
					public long? GlobalToPercent{
						get{return response.GetLong("globalToPercent");}
					}
			/// <summary>
			/// The number of friend entries the player has in this leaderboard.
			/// </summary>
					public long? SocialCount{
						get{return response.GetLong("socialCount");}
					}
			/// <summary>
			/// The Social Rank of the player in this leaderboard before the score was submitted.
			/// </summary>
					public long? SocialFrom{
						get{return response.GetLong("socialFrom");}
					}
			/// <summary>
			/// The old social rank of the player as a percentage of the total number of friend scores in this leaderboard.
			/// </summary>
					public long? SocialFromPercent{
						get{return response.GetLong("socialFromPercent");}
					}
			/// <summary>
			/// The Social Rank of the player in this leaderboard after the score was submitted.
			/// </summary>
					public long? SocialTo{
						get{return response.GetLong("socialTo");}
					}
			/// <summary>
			/// The old global rank of the player as a percentage of the total number of friend scores in this leaderboard.
			/// </summary>
					public long? SocialToPercent{
						get{return response.GetLong("socialToPercent");}
					}
			/// <summary>
			/// The leaderboard entries of the global players that were beaten as part of this score submission. Requires Top N to be configured on the leaderboard
			/// </summary>
					public GSEnumerable<_LeaderboardData> TopNPassed{
						get{return new GSEnumerable<_LeaderboardData>(response.GetObjectList("topNPassed"), (data) => { return new _LeaderboardData(data);});}
					}
			
			
		}
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
			/// The new leaderboard data associated with this message.
			/// </summary>
					public _LeaderboardData LeaderboardData{
						get{
							if(response.GetObject("leaderboardData") == null) { return null; }
							return new _LeaderboardData(response.GetObject("leaderboardData"));
						}
					}
			/// <summary>
			/// The leaderboard's name.
			/// </summary>
					public String LeaderboardName{
						get{return response.GetString("leaderboardName");}
					}
			/// <summary>
			/// The leaderboard shortcode.
			/// </summary>
					public String LeaderboardShortCode{
						get{return response.GetString("leaderboardShortCode");}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// The ranking information for the new score.
			/// </summary>
					public _LeaderboardRankDetails RankDetails{
						get{
							if(response.GetObject("rankDetails") == null) { return null; }
							return new _LeaderboardRankDetails(response.GetObject("rankDetails"));
						}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
	}
	
	
	public class NewTeamScoreMessage : GSMessage
	{
		public NewTeamScoreMessage(GSData data) : base(data){}
		
		public static Action<NewTeamScoreMessage> Listener;

		private static NewTeamScoreMessage Create(GSData data)
		{
			NewTeamScoreMessage message = new NewTeamScoreMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".NewTeamScoreMessage"] = Create;
		}
		
		/// <summary>
		/// Ranking information.
		/// </summary>
		public class _LeaderboardRankDetails : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _LeaderboardRankDetails(GSData data) : base(data){}
			
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
			/// The leaderboard entries of the players friends that were beaten as part of this score submission.
			/// </summary>
					public GSEnumerable<_LeaderboardData> FriendsPassed{
						get{return new GSEnumerable<_LeaderboardData>(response.GetObjectList("friendsPassed"), (data) => { return new _LeaderboardData(data);});}
					}
			/// <summary>
			/// The number of entries in this leaderboard.
			/// </summary>
					public long? GlobalCount{
						get{return response.GetLong("globalCount");}
					}
			/// <summary>
			/// The Global Rank of the player in this leaderboard before the score was submitted.
			/// </summary>
					public long? GlobalFrom{
						get{return response.GetLong("globalFrom");}
					}
			/// <summary>
			/// The old global rank of the player as a percentage of the total number of scores in this leaderboard .
			/// </summary>
					public long? GlobalFromPercent{
						get{return response.GetLong("globalFromPercent");}
					}
			/// <summary>
			/// The Global Rank of the player in this leaderboard after the score was submitted.
			/// </summary>
					public long? GlobalTo{
						get{return response.GetLong("globalTo");}
					}
			/// <summary>
			/// The new global rank of the player as a percentage of the total number of scores in this leaderboard .
			/// </summary>
					public long? GlobalToPercent{
						get{return response.GetLong("globalToPercent");}
					}
			/// <summary>
			/// The number of friend entries the player has in this leaderboard.
			/// </summary>
					public long? SocialCount{
						get{return response.GetLong("socialCount");}
					}
			/// <summary>
			/// The Social Rank of the player in this leaderboard before the score was submitted.
			/// </summary>
					public long? SocialFrom{
						get{return response.GetLong("socialFrom");}
					}
			/// <summary>
			/// The old social rank of the player as a percentage of the total number of friend scores in this leaderboard.
			/// </summary>
					public long? SocialFromPercent{
						get{return response.GetLong("socialFromPercent");}
					}
			/// <summary>
			/// The Social Rank of the player in this leaderboard after the score was submitted.
			/// </summary>
					public long? SocialTo{
						get{return response.GetLong("socialTo");}
					}
			/// <summary>
			/// The old global rank of the player as a percentage of the total number of friend scores in this leaderboard.
			/// </summary>
					public long? SocialToPercent{
						get{return response.GetLong("socialToPercent");}
					}
			/// <summary>
			/// The leaderboard entries of the global players that were beaten as part of this score submission. Requires Top N to be configured on the leaderboard
			/// </summary>
					public GSEnumerable<_LeaderboardData> TopNPassed{
						get{return new GSEnumerable<_LeaderboardData>(response.GetObjectList("topNPassed"), (data) => { return new _LeaderboardData(data);});}
					}
			
			
		}
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
			/// The new leaderboard data associated with this message.
			/// </summary>
					public _LeaderboardData LeaderboardData{
						get{
							if(response.GetObject("leaderboardData") == null) { return null; }
							return new _LeaderboardData(response.GetObject("leaderboardData"));
						}
					}
			/// <summary>
			/// The leaderboard's name.
			/// </summary>
					public String LeaderboardName{
						get{return response.GetString("leaderboardName");}
					}
			/// <summary>
			/// The leaderboard shortcode.
			/// </summary>
					public String LeaderboardShortCode{
						get{return response.GetString("leaderboardShortCode");}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// The ranking information for the new score.
			/// </summary>
					public _LeaderboardRankDetails RankDetails{
						get{
							if(response.GetObject("rankDetails") == null) { return null; }
							return new _LeaderboardRankDetails(response.GetObject("rankDetails"));
						}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
	}
	
	
	public class ScriptMessage : GSMessage
	{
		public ScriptMessage(GSData data) : base(data){}
		
		public static Action<ScriptMessage> Listener;

		private static ScriptMessage Create(GSData data)
		{
			ScriptMessage message = new ScriptMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".ScriptMessage"] = Create;
		}
		
			/// <summary>
			/// JSON data sent from a Cloud Code script.
			/// </summary>
					public GSData Data{
						get{return response.GetObject("data");}
					}
			/// <summary>
			/// The extension code used when creating this script message
			/// </summary>
					public String ExtCode{
						get{return response.GetString("extCode");}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
	}
	
	
	public class SessionTerminatedMessage : GSMessage
	{
		public SessionTerminatedMessage(GSData data) : base(data){}
		
		public static Action<SessionTerminatedMessage> Listener;

		private static SessionTerminatedMessage Create(GSData data)
		{
			SessionTerminatedMessage message = new SessionTerminatedMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".SessionTerminatedMessage"] = Create;
		}
		
			/// <summary>
			/// Used to automatically re-authenticate a client during socket connect.
			/// </summary>
					public String AuthToken{
						get{return response.GetString("authToken");}
					}
	}
	
	
	public class SocialRankChangedMessage : GSMessage
	{
		public SocialRankChangedMessage(GSData data) : base(data){}
		
		public static Action<SocialRankChangedMessage> Listener;

		private static SocialRankChangedMessage Create(GSData data)
		{
			SocialRankChangedMessage message = new SocialRankChangedMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".SocialRankChangedMessage"] = Create;
		}
		
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
			/// The game id that this message relates to.
			/// </summary>
					public long? GameId{
						get{return response.GetLong("gameId");}
					}
			/// <summary>
			/// The leaderboard's name.
			/// </summary>
					public String LeaderboardName{
						get{return response.GetString("leaderboardName");}
					}
			/// <summary>
			/// The leaderboard shortcode.
			/// </summary>
					public String LeaderboardShortCode{
						get{return response.GetString("leaderboardShortCode");}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// The score details of the player whose score the receiving player has passed.
			/// </summary>
					public _LeaderboardData Them{
						get{
							if(response.GetObject("them") == null) { return null; }
							return new _LeaderboardData(response.GetObject("them"));
						}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
			/// <summary>
			/// The score details of the receiving player.
			/// </summary>
					public _LeaderboardData You{
						get{
							if(response.GetObject("you") == null) { return null; }
							return new _LeaderboardData(response.GetObject("you"));
						}
					}
	}
	
	
	public class TeamChatMessage : GSMessage
	{
		public TeamChatMessage(GSData data) : base(data){}
		
		public static Action<TeamChatMessage> Listener;

		private static TeamChatMessage Create(GSData data)
		{
			TeamChatMessage message = new TeamChatMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".TeamChatMessage"] = Create;
		}
		
			/// <summary>
			/// The identifier for this message as it appears in the chat history.
			/// </summary>
					public String ChatMessageId{
						get{return response.GetString("chatMessageId");}
					}
			/// <summary>
			/// The player's id who is sending the message.
			/// </summary>
					public String FromId{
						get{return response.GetString("fromId");}
					}
			/// <summary>
			/// The message to send to the team.
			/// </summary>
					public String Message{
						get{return response.GetString("message");}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// The id of the owner
			/// </summary>
					public String OwnerId{
						get{return response.GetString("ownerId");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// The id of the team
			/// </summary>
					public String TeamId{
						get{return response.GetString("teamId");}
					}
			/// <summary>
			/// The team type
			/// </summary>
					public String TeamType{
						get{return response.GetString("teamType");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
			/// <summary>
			/// The name of the player who is sending the message.
			/// </summary>
					public String Who{
						get{return response.GetString("who");}
					}
	}
	
	
	public class TeamRankChangedMessage : GSMessage
	{
		public TeamRankChangedMessage(GSData data) : base(data){}
		
		public static Action<TeamRankChangedMessage> Listener;

		private static TeamRankChangedMessage Create(GSData data)
		{
			TeamRankChangedMessage message = new TeamRankChangedMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".TeamRankChangedMessage"] = Create;
		}
		
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
			/// The game id that this message relates to.
			/// </summary>
					public long? GameId{
						get{return response.GetLong("gameId");}
					}
			/// <summary>
			/// The leaderboard's name.
			/// </summary>
					public String LeaderboardName{
						get{return response.GetString("leaderboardName");}
					}
			/// <summary>
			/// The leaderboard shortcode.
			/// </summary>
					public String LeaderboardShortCode{
						get{return response.GetString("leaderboardShortCode");}
					}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// The score details of the team whose score the receiving team's players have passed.
			/// </summary>
					public _LeaderboardData Them{
						get{
							if(response.GetObject("them") == null) { return null; }
							return new _LeaderboardData(response.GetObject("them"));
						}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
			/// <summary>
			/// The score details of the receiving team.
			/// </summary>
					public _LeaderboardData You{
						get{
							if(response.GetObject("you") == null) { return null; }
							return new _LeaderboardData(response.GetObject("you"));
						}
					}
	}
	
	
	public class UploadCompleteMessage : GSMessage
	{
		public UploadCompleteMessage(GSData data) : base(data){}
		
		public static Action<UploadCompleteMessage> Listener;

		private static UploadCompleteMessage Create(GSData data)
		{
			UploadCompleteMessage message = new UploadCompleteMessage (data);
			return message;
		}

		override public void NotifyListeners()
		{
			if (Listener != null)
			{
				Listener (this);
			}
		}


		internal static void RegisterMessageType()
		{
			handlers[".UploadCompleteMessage"] = Create;
		}
		
		/// <summary>
		/// This object represents the result of uploading a file to the GameSparks platform.
		/// </summary>
		public class _UploadData : GSTypedResponse{
		
			/// <summary>
			/// Constructor
			/// </summary>
			public _UploadData(GSData data) : base(data){}
			
			/// <summary>
			/// The filename of the file that was uploaded.
			/// </summary>
					public String FileName{
						get{return response.GetString("fileName");}
					}
			/// <summary>
			/// The unique player id of the player that uploaded the file.
			/// </summary>
					public String PlayerId{
						get{return response.GetString("playerId");}
					}
			
			
		}
			/// <summary>
			/// A unique identifier for this message.
			/// </summary>
					public String MessageId{
						get{return response.GetString("messageId");}
					}
			/// <summary>
			/// Flag indicating whether this message could be sent as a push notification or not.
			/// </summary>
					public bool? Notification{
						get{return response.GetBoolean("notification");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String SubTitle{
						get{return response.GetString("subTitle");}
					}
			/// <summary>
			/// A textual summary describing the message's purpose.
			/// </summary>
					public String Summary{
						get{return response.GetString("summary");}
					}
			/// <summary>
			/// A textual title for the message.
			/// </summary>
					public String Title{
						get{return response.GetString("title");}
					}
			/// <summary>
			/// The upload data (if supplied as part of GetUploadUrlRequest) of UploadData objects
			/// </summary>
					public _UploadData UploadData{
						get{
							if(response.GetObject("uploadData") == null) { return null; }
							return new _UploadData(response.GetObject("uploadData"));
						}
					}
			/// <summary>
			/// The id of the upload
			/// </summary>
					public String UploadId{
						get{return response.GetString("uploadId");}
					}
	}
	
	
}

#pragma warning restore 612, 618
#pragma warning restore 0114
#pragma warning disable 0108

