using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace SpaceInvadersRetro.Utils;

public abstract class SoundManager
{
    private static Song _backgroundMusic;
    private static ContentManager _content;

    public static void CreateInstance(ContentManager content)
    {
        _content ??= content;
        LoadSong();
    }

    private static void LoadSong()
    {
        _backgroundMusic = _content.Load<Song>("Sounds/spaceinvadersmusic");
    }

    public static void PlaySong(float volume, bool repeat)
    {
        MediaPlayer.IsRepeating = repeat;
        MediaPlayer.Volume -= volume;
        MediaPlayer.Play(_backgroundMusic);
    }

    public static void PauseSong()
    {
        MediaPlayer.Pause();
    }

    public static void ResumeSong()
    {
        MediaPlayer.Resume();
    }

    public static void StopSong()
    {
        MediaPlayer.Stop();
    }

    public static void PlaySoundEffect(string effectName)
    {
        var soundEffect = _content.Load<SoundEffect>($"Sounds/{effectName}");
        soundEffect.Play();
    }
}
