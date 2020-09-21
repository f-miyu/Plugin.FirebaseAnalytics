using System;
namespace Plugin.FirebaseAnalytics
{
    public static class EventName
    {
        public static readonly string AddPaymentInfo = "add_payment_info";
        public static readonly string AddShippingInfo = "add_shipping_info";
        public static readonly string AddToCart = "add_to_cart";
        public static readonly string AddToWishlist = "add_to_wishlist";
        public static readonly string AppOpen = "app_open";
        public static readonly string BeginCheckout = "begin_checkout";
        public static readonly string CampaignDetails = "campaign_details";
        public static readonly string CheckoutProgress = "checkout_progress";
        public static readonly string EarnVirtualCurrency = "earn_virtual_currency";
        [Obsolete("Use Purchase instead.")]
        public static readonly string EcommercePurchase = "ecommerce_purchase";
        public static readonly string GenerateLead = "generate_lead";
        public static readonly string JoinGroup = "join_group";
        public static readonly string LevelEnd = "level_end";
        public static readonly string LevelStart = "level_start";
        public static readonly string LevelUp = "level_up";
        public static readonly string Login = "login";
        public static readonly string PostScore = "post_score";
        [Obsolete("Use ViewPromotion instead.")]
        public static readonly string PresentOffer = "present_offer";
        public static readonly string Purchase = "purchase";
        [Obsolete("Use Refund instead.")]
        public static readonly string PurchaseRefund = "purchase_refund";
        public static readonly string Refund = "refund";
        public static readonly string RemoveFromCart = "remove_from_cart";
        public static readonly string Search = "search";
        public static readonly string SelectContent = "select_content";
        public static readonly string SelectItem = "select_item";
        public static readonly string SelectPromotion = "select_promotion";
        [Obsolete("deprecated")]
        public static readonly string SetCheckoutOption = "set_checkout_option";
        public static readonly string Share = "share";
        public static readonly string SignUp = "sign_up";
        public static readonly string SpendVirtualCurrency = "spend_virtual_currency";
        public static readonly string TutorialBegin = "tutorial_begin";
        public static readonly string TutorialComplete = "tutorial_complete";
        public static readonly string UnlockAchievement = "unlock_achievement";
        public static readonly string ViewCart = "view_cart";
        public static readonly string ViewItem = "view_item";
        public static readonly string ViewItemList = "view_item_list";
        public static readonly string ViewPromotion = "view_promotion";
        public static readonly string ViewSearchResults = "view_search_results";
    }
}
