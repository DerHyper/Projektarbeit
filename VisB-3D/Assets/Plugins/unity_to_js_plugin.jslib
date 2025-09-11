mergeInto(LibraryManager.library, {
  /**
   * Debug method for checking if Unity can call JS.
   */ 
  DebugAlert: function (str) {
    window.alert(UTF8ToString(str));
  },

  /**
   * Connect to a WebSocket server.
   * @param {string} urlUTF String URL of the WebSocket server, eg "ws://localhost:8080"
   */
  ConnectWS: function (urlUTF) {
    const url = UTF8ToString(urlUTF);
    console.log("Connecting to WebSocket at: " + url);
    
    ws = new WebSocket();

    ws.on("open", () => {
      console.log("WebSocket connection opened.");
      SendMessage("WebSocketManager", "OnWebSocketOpen"); // Call Unity method
    })
  }
});