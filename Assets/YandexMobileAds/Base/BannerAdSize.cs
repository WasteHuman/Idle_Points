/*
 * This file is a part of the Yandex Advertising Network
 *
 * Version for Unity (C) 2023 YANDEX
 *
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at https://legal.yandex.com/partner_ch/
 */

namespace YandexMobileAds.Base
{
    /// <summary>
    /// Banner size type
    /// </summary>
    public enum BannerAdSizeType
    {
        /// with specified height and width of the banner
        Fixed,
        /// with the specified maximum height and width of the banner
        Inline,
        /// with the specified maximum width of a sticky banner
        Sticky
    }

    /// <summary>
    /// This class is responsible for the banner size.
    /// </summary>
    public class BannerAdSize
    {
        private const int NotSpecified = -1;

        /// <summary>
        /// The initial width of the banner
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// The initial height of the banner
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Banner size type
        /// </summary>
        public BannerAdSizeType AdSizeType { get; private set; }

        /// <summary>
        /// Creates an object of the <see cref="BannerAdSize"/>class with the specified width and height of the banner.
        /// <para>This method is available for internal sdk logic.</para>
        /// <para>We do not recommend using a banner of this size, its use in the application may negatively affect
        /// monetization.</para>
        /// <para>Use <see cref="StickySize"/> for small automatically updated banner attached to the the top or bottom
        /// of the screen, or use <see cref="InlineSize"/> for adaptive banner placed in scrolling content.</para>
        /// </summary>
        /// <param name="width">The width of the ad container in pixels.</param>
        /// <param name="height">The height of the ad container in pixels.</param>
        /// <returns>
        /// An object of the <see cref="BannerAdSize"/> class with the specified width and height of the banner.
        /// </returns>
        public static BannerAdSize FixedSize(int width, int height)
        {
            return new BannerAdSize {Width = width, Height = height, AdSizeType = BannerAdSizeType.Fixed};
        }

        /// <summary>
        /// Creates an object of the <see cref="BannerAdSize"/> class with the specified maximum width of a sticky
        /// banner.
        /// </summary>
        /// <param name="width">Maximum width available for a banner.</param>
        /// <returns>
        /// An object of the <see cref="BannerAdSize"/> class with the specified maximum width of a sticky banner
        /// </returns>
        public static BannerAdSize StickySize(int width)
        {
            return new BannerAdSize {Width = width, Height = NotSpecified, AdSizeType = BannerAdSizeType.Sticky};
        }

        /// <summary>
        /// Creates an object of the <see cref="BannerAdSize"/>  class with the specified maximum height and width of
        /// the banner.
        /// </summary>
        /// <param name="width">The width of the ad container in density-independent pixels (dp).</param>
        /// <param name="maxHeight">Maximum height of the ad container in density-independent pixels (dp).</param>
        /// <returns>
        /// An object of the <see cref="BannerAdSize"/> class with the specified maximum height and width of the banner.
        /// </returns>
        public static BannerAdSize InlineSize(int width, int maxHeight)
        {
            return new BannerAdSize {Width = width, Height = maxHeight, AdSizeType = BannerAdSizeType.Inline};
        }
    }
}
