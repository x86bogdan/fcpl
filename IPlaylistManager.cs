using System.Collections.Generic;

// The contract for our Playlist Manager
public interface IPlaylistManager
{
    // Uses 'out' to safely find a song without causing errors if it's not found.
    bool TryGetSong(string title, out Song foundSong);

    // Uses 'in' for a safe, read-only operation.
    // Assumes 'Song' is a struct for this example to highlight 'in'.
    bool IsSongInPlaylist(in Song songToCheck);

    // Uses 'params' to add multiple songs in a single, clean method call.
    void AddSongs(params Song[] songsToAdd);
}
