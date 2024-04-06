// In development, always fetch from the network and do not enable offline support.
// This is because caching would make development more difficult (changes would not
// be reflected on the first load after each change).


//self.addEventListener('fetch', () => { });



self.addEventListener('install', (event) => {
    event.waitUntil(
        caches.open('v1').then((cache) => {
            return cache.addAll([
                // Add URLs of files you want to cache
                '/',
                '/index.html',
                '/css/site.css',
                '/_framework/blazor.webassembly.js',
                // Add more files as needed
            ]);
        })
    );
});

self.addEventListener('fetch', (event) => {
    event.respondWith(
        caches.match(event.request).then((response) => {
            return response || fetch(event.request);
        })
    );
});