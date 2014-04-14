angular.module('dharmaTalksServices', [])
    .service('nowPlayingModel', function() {
        var self = this;
        self.callbacks = [];
        self.model = {
            url: null,
            item: null,
            isPlaying: false,
            isPaused: false
        };

        self.fireCallbacks = function() {
            for (var i = 0; i < self.callbacks.length; i++) {
                self.callbacks[i](self.model);
            }
        };

        self.addCallback = function(callback) {
            self.callbacks.push(callback);
            callback(self.model);
        };
        
        var service = {
            play: function(url, item) {
                self.model.url = url;
                self.model.item = item;
                self.model.isPlaying = true;
                self.model.isPaused = false;
                
                // TODO: Load media if necessary
                self.fireCallbacks();
            },
            stop: function() {
                self.model.url = null;
                self.model.item = null;
                self.model.isPlaying = false;
                self.model.isPaused = false;
                self.fireCallbacks();
            },
            pause: function() {
                self.model.isPaused = true;
            },
            bindTo: function(callback) {
                self.addCallback(callback);
            },
            getModel: function() {
                return self.model;
            },
            player: null,
            playerData: null
        };

        return service;
    })
    //.service('XmlParser', function() {
    //    var parseXml;

    //    if (typeof window.DOMParser != "undefined") {
    //        parseXml = function (xmlStr) {
    //            return (new window.DOMParser()).parseFromString(xmlStr, "text/xml");
    //        };
    //    } else if (typeof window.ActiveXObject != "undefined" &&
    //           new window.ActiveXObject("Microsoft.XMLDOM")) {
    //        parseXml = function (xmlStr) {
    //            var xmlDoc = new window.ActiveXObject("Microsoft.XMLDOM");
    //            xmlDoc.async = "false";
    //            xmlDoc.loadXML(xmlStr);
    //            return xmlDoc;
    //        };
    //    } else {
    //        throw new Error("No XML parser found");
    //    }

    //    return parseXml;
    //})
    .service('talkService', function($http, $q) {
        var talks = {};

        var addTalks = function(newTalks) {
            for (var i = 0; i < newTalks.length; i++) {
                talks[newTalks[i].id] = newTalks[i];
            }
        };

        var getTalk = function(talkId) {
            if (talkId in talks) {
                var deferred = $q.defer();
                deferred.resolve(talks[talkId]);
                return deferred.promise;
            } else {
                var promise = $http.get('http://localhost/dhammatalks-web/talks/' + talkId);
                promise = promise.then(function(result) {
                    var talk = result.data;

                    // Add the talks to the TalkService
                    addTalks([talk]);

                    return talk;
                });

                return promise;
            }
        };

        return {
            addTalks: addTalks,
            getTalk: getTalk
        };
    })
    .service('recentTalks', ['$http', 'talkService', function ($http, talkService) {
        //var decodeFromXml = function(text) {
        //    return text.replace(/&amp;/g, '&')
        //                   .replace(/&lt;/g, '<')
        //                   .replace(/&gt;/g, '>')
        //                   .replace(/&quot;/g, '"');
        //    };

        var promise = $http.get('http://localhost/dhammatalks-web/talks/recent/30');
        promise = promise.then(function(result) {
            var talks = result.data;
            
            // Add the talks to the TalkService
            talkService.addTalks(talks);
            
            return talks;
        });

        return promise;
    }]);
