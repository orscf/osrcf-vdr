﻿//using System;
//using System.ComponentModel.DataAnnotations;
//using System.Collections.ObjectModel;
//using System.Collections.Generic;
//using H7 = Hl7.Fhir.Model;
//using MedicalResearch.VisitData.Model;

//namespace MedicalResearch.VisitData {

//  /// <summary> Provides an workflow-level API for interating with a 'VisitDataRepository' (VDR) </summary>
//  public partial interface IVdrEventSubscriptionService {

//    #region " Visits "

//    /// <summary>
//    /// Creates a subscription for changes which are affecting Visits.
//    /// On success, a 'SubscriptionUid' will be returned and a call will be made to the given
//    /// subscriberUrl + '/ConfirmAsSubscriber'. After the subscription
//    /// has been confirmed, the requested events will be pushed to
//    /// subscriberUrl + '/NoticeChangedVisits'
//    /// (NOTICE: the receiving methods also are documented here, because this service itself can act as subscriber)
//    /// </summary>
//    /// <param name="subscriberUrl"> 
//    ///  the root-url of the subscriber which needs to provide at least the methods 
//    /// '/ConfirmAsSubscriber' and '/NoticeChangedVisits'
//    /// </param>
//    /// <param name="filter">
//    ///   if provided, the subscription will only publish events for
//    ///   records matching to the given filter
//    /// </param>
//    /// <returns></returns>
//    Guid SubscribeForChangedVisits(
//      string subscriberUrl,
//      VisitFilter filter = null
//    );

//    /// <summary>
//    ///   Receives notifications about changes which are affecting Visits.
//    ///   IMPORTANT: this method is dedicated to the usecase, when this service itself acts as a subscriber!
//    ///   So this can be called by an foreign service during the setup of a subscription, which was previously
//    ///   requested from here.
//    ///   The opposite case: any client subscribing to events from here,
//    ///   must provide its own http endpoint that has such a method!
//    /// </summary>
//    /// <param name="eventUid"> a UUID which identifies the current event message </param>
//    /// <param name="eventSignature">
//    /// a SHA256 Hash of SubscriptionSecret + EventUid
//    /// (in lower string representation, without '-' characters!)
//    /// Sample: SHA256('ThEs3Cr3T'+'c997dfb1c445fea84afe995307713b59')
//    /// = 'a320ef5b0f563e8dcb16d759961739977afc98b90628d9dc3be519fb20701490'
//    /// </param>
//    /// <param name="subscriptionUid"> a UUID which identifies the subscription for which this event is published  </param>
//    /// <param name="publisherUrl"> root-URL of the VDR-Service which is publishing this event </param>
//    /// <param name="changes"> an array, which contains one element per changed visit </param>
//    /// <param name="terminateSubscription"> an array, which contains one element per changed visit </param>
//    /// <returns></returns>
//    void NoticeChangedVisits(
//      Guid eventUid,
//      string eventSignature,
//      Guid subscriptionUid,
//      string publisherUrl,
//      VisitMetaRecord[] createdRecords,
//      VisitMetaRecord[] modifiedRecords,
//      VisitMetaRecord[] archivedRecords,
//      out bool terminateSubscription
//    );

//    #endregion

//    #region " (Confirmation & Termination) "

//    /// <summary>
//    ///   Confirms a Subscription.
//    ///   IMPORTANT: this method is dedicated to the usecase, when this service itself acts as a subscriber!
//    ///   So this can be called by an foreign service during the setup of a subscription, which was previously
//    ///   requested from here.
//    ///   The opposite case: any client subscribing to events from here,
//    ///   must provide its own http endpoint that has such a method!
//    /// </summary>
//    /// <param name="publisherUrl"> root-URL of the VDR-Service on which the subscription was requested </param>
//    /// <param name="subscriptionUid"> the Uid of the subscription which should be confirmed </param>
//    /// <param name="secret">
//    ///   A secret which is generated by the subscriber and used to provide additional security.
//    ///   It will be required for the 'TerminateSubscription' method and it is used to generate
//    ///   SHA256 hashes for signing the delivered event messages.
//    ///   The secret should: have a minimum length of 32 characters.
//    ///   A null or empty string has the semantics that the subscriber refuses to confirm
//    ///   and cancels the subscription setup.
//    ///   </param>
//    /// <returns></returns>
//    void ConfirmAsSubscriber(
//      string publisherUrl,
//      Guid subscriptionUid,
//      out string secret
//    );

//    /// <summary>
//    /// Terminates a subscription (on publisher side) and returns a boolean,
//    /// which indicates success.
//    /// </summary>
//    /// <param name="subscriptionUid"> the Uid of the subscription which should be terminated </param>
//    /// <param name="secret"> the (same) secret, which was given by the subscriber during the subscription setup </param>
//    /// <returns></returns>
//    bool TerminateSubscription(
//      Guid subscriptionUid,
//      string secret
//    );

//    /// <summary>
//    /// Returns an array of subscriptionUid's.
//    /// This method helps subscribers to evaluate whether current subscriptions are still active.
//    /// </summary>
//    /// <param name="subscriberUrl"></param>
//    /// <param name="secret"> the (same) secret, which was given by the subscriber during the subscription setup </param>
//    /// <returns></returns>
//    Guid[] GetSubsriptionsBySubscriberUrl(
//      string subscriberUrl,
//      string secret
//    );

//    #endregion

//  }

//}
