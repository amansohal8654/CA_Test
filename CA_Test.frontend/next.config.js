const defaultTheme = require('tailwindcss/defaultTheme')

/** @type {import('tailwindcss').Config} */
module.exports = {
    trailingSlash: true,
    reactStrictMode: true,
    swcMinify: true,
    experimental: {
      newNextLinkBehavior: true,
      scrollRestoration: true,
    },
    images: {
      deviceSizes: [640, 750, 828, 1080, 1200, 1920, 2048, 3840],
      // limit of 25 imageSizes values
      imageSizes: [16, 32, 48, 64, 96, 128, 256, 384],
      // disable static imports for image files
      disableStaticImages: false,
      // minimumCacheTTL is in seconds, must be integer 0 or more
      minimumCacheTTL: 60,
      // ordered list of acceptable optimized image formats (mime types)
      formats: ['image/webp'],
      // enable dangerous use of SVG images
      dangerouslyAllowSVG: false,
      // set the Content-Security-Policy header
      contentSecurityPolicy: "default-src 'self'; script-src 'none'; sandbox;",
      // the following are experimental features, and may cause breaking changes
      domains: ['localhost', 'firebasestorage.googleapis.com', 'images.unsplash.com', 'tailwindui.com', 'www.bing.com', 'us-central1-enlist-project.cloudfunctions.net', 'storage.googleapis.com'],
    },
    env: {
      Localhost_Endpoint: 'http://localhost:3365'
    },
  }