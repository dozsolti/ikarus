let socket = null;
// const ikarusListeners = {};

let GameSmartJS = {
    $dependencies: {},
    Connect: function (OnInputCallback) {
        this.socket = io("ws://127.0.0.1:3000", {
            transports: ["websocket"],
            path: "/server",
            query: { type: "game" },
        });
        function getPtrFromString(str1) {
            var len1 = lengthBytesUTF8(str1) + 1;
            var strPtr1 = _malloc(len1);
            stringToUTF8(str1, strPtr1, len1);
            return strPtr1;
        }
        console.log("Connected");
        this.socket.on("input", function (data) {

            Module.dynCall_vi(OnInputCallback, 
                getPtrFromString(JSON.stringify(data))
            );

            // Runtime.dynCall("vi", OnInputCallback, [
            //     getPtrFromString(JSON.stringify(data)),
            // ]);
        });
        console.log("Finished");
    },
    Clo: function (message) {
        console.log("message", message);
    },
};

autoAddDeps(GameSmartJS, "$dependencies");
mergeInto(LibraryManager.library, GameSmartJS);
/*
const connect = () => {
    socket = io("ws://127.0.0.1:3000", {
        transports: ["websocket"],
        path: "/server",
        query: { type: "game" },
    });

    socket.on("input", (input) => {
        console.log({ input });
        for (const listener of Object.values(ikarusListeners)) {
            const name = input.data.name;
            if (
                listener.type === input.type && // joystick == button
                input.eventType === listener.eventType // move == up
            ) {
                listener.callback(name, input.data);
            }
        }
    });
};

const addListener = (type, eventType, callback) => {
    const id = (Math.random() * 100000).toFixed(0);
    ikarusListeners[id] = { type, eventType, callback };
    return id;
};

const removeListener = (id) => {
    delete ikarusListeners[id];
};
*/
