function TestOneCtrl($scope) {
    $scope.play = function() {
        
    };

    $scope.stop = function() {

    };
}

function NowPlayingCtrl($scope, $location, nowPlayingModel) {
    nowPlayingModel.bindTo(function(model) {
        $scope.isPlaying = model.isPlaying;
    });

    $scope.goTo = function() {
        $location.url(nowPlayingModel.getModel().url);
    };
}

function HomeCtrl($scope) {
    
}

function RecentTalksCtrl($scope, recentTalks) {
    recentTalks.then(function(result) {
        $scope.talks = result;
    });
}

function TalkCtrl($scope, $routeParams, $location, talkService, nowPlayingModel) {
    $scope.safeApply = function (fn) {
        var phase = this.$root.$$phase;
        if (phase == '$apply' || phase == '$digest') {
            if (fn && (typeof (fn) === 'function')) {
                fn($scope);
            }
        } else {
            this.$apply(fn);
        }
    };

    $scope.player = nowPlayingModel.player;

    $scope.ready = false;
    $scope.isMediaLoaded = false;

    talkService.getTalk($routeParams.talkId).then(function(data) {
        $scope.talk = data;
        $scope.ready = true;
    });

    // Load and play the audio
    $scope.loadMedia = function(reset) {
        $scope.player.unbind(".TalkCtrl"); // Unbind any previous event listener
        $scope.player.bind($.jPlayer.event.timeupdate + ".TalkCtrl", function (event) {
            $scope.safeApply(function (scope) {
                scope.playerData = event.jPlayer;
                scope.currentTime = event.jPlayer.status.currentTime;
                nowPlayingModel.playerData = event.jPlayer; // Store the playerdata on the model so it's persisted if the user goes and comes back
            });
        });

        if (reset) {
            $scope.player.jPlayer('setMedia', { mp3: $scope.talk.mediaUrl });
            $scope.player.jPlayer('play');

            // Record the fact that we're playing with the shared service
            nowPlayingModel.play($location.url(), $scope.talk);
            $scope.isPlaying = true;
        } else {
            // Retrieve any player data previously stored on the shared model
            // TODO: Tidy this up
            $scope.playerData = nowPlayingModel.playerData;
            $scope.currentTime = nowPlayingModel.playerData.status.currentTime;
            $scope.isPlaying = !nowPlayingModel.getModel().isPaused;
        }
        
        $scope.isMediaLoaded = true;
    };

    $scope.playPause = function() {
        if ($scope.isPlaying) {
            $scope.player.jPlayer('pause');
            nowPlayingModel.pause();
        } else {
            $scope.player.jPlayer('play');
            nowPlayingModel.play($location.url(), $scope.talk);
        }

        $scope.isPlaying = !$scope.isPlaying;
    };
    
    // Check if this talk is already being played
    if (nowPlayingModel.getModel().url == $location.url()) {
        // Already playing this one...
        $scope.loadMedia(false);
    }
}