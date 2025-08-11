// Debug method for checking if Unity can call JS.
mergeInto(LibraryManager.library, {
  DebugAlert: function (str) {
    window.alert(UTF8ToString(str));
  },
});