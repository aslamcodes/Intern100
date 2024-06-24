# Main file

The main file (usually labelled `main.scss`) should be the only Sass file from the whole code base not to begin with an underscore. This file should not contain anything but `@import` and comments.

_Note: when using [Eyeglass](https://github.com/sass-eyeglass/eyeglass) for distribution, it might be a fine idea to name this file `index.scss` rather than `main.scss` in order to stick to [Eyeglass modules specifications](https://github.com/sass-eyeglass/eyeglass#writing-an-eyeglass-module-with-sass-files). See [#21](https://github.com/KittyGiraudel/sass-boilerplate/issues/21) for reference._

Reference: [Sass Guidelines](https://sass-guidelin.es/) > [Architecture](https://sass-guidelin.es/#architecture) > [Main file](https://sass-guidelin.es/#main-file)

1. Differentiate logged in vs not logged in content (JWT)
2. No unnessecary info on console, (clean before presentign)
3. Page not found error
4. Menu are required, Handle as yourre the user
5. Search and filters
6. My Orders
7. Logout is needed
8. Responsiveness is not required
9. Validations are on essential, not on creativity, although encouraged
10. Deadline at 26th June
11. Hit the essentials first, the crictical.
