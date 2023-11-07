using System;

// Интерфейс музыкального плеера
public interface IMusicPlayer
{
    void Play();
    void Pause();
    void Stop();
    void Next();
    void Previous();
    void SetVolume(int volume);
    void AddToPlaylist(string song);
    void RemoveFromPlaylist(string song);
    void DisplayCurrentSong();
    void DisplayPlayerState();
    void DisplayPlaylist();
}

// Класс музыкального плеера
public class MusicPlayer : IMusicPlayer
{
    private string currentSong;
    private int volume;
    private bool isPlaying;
    private string[] playlist = new string[10];
    private int playlistIndex = 0;

    public void Play()
    {
        isPlaying = true;
        Console.WriteLine("Воспроизведение начато.");
    }

    public void Pause()
    {
        isPlaying = false;
        Console.WriteLine("Воспроизведение приостановлено.");
    }

    public void Stop()
    {
        isPlaying = false;
        Console.WriteLine("Воспроизведение остановлено.");
    }

    public void Next()
    {
        playlistIndex++;
        if (playlistIndex >= playlist.Length)
        {
            playlistIndex = 0;
        }
        currentSong = playlist[playlistIndex];
        Console.WriteLine("Переключено на следующую песню.");
    }

    public void Previous()
    {
        playlistIndex--;
        if (playlistIndex < 0)
        {
            playlistIndex = playlist.Length - 1;
        }
        currentSong = playlist[playlistIndex];
        Console.WriteLine("Переключено на предыдущую песню.");
    }

    public void SetVolume(int volume)
    {
        this.volume = volume;
        Console.WriteLine($"Громкость установлена на {volume}%.");
    }

    public void AddToPlaylist(string song)
    {
        if (playlistIndex < playlist.Length)
        {
            playlist[playlistIndex] = song;
            playlistIndex++;
            Console.WriteLine($"Песня '{song}' добавлена в плейлист.");
        }
        else
        {
            Console.WriteLine("Плейлист полон. Нельзя добавить больше песен.");
        }
    }

    public void RemoveFromPlaylist(string song)
    {
        for (int i = 0; i < playlist.Length; i++)
        {
            if (playlist[i] == song)
            {
                playlist[i] = null;
                Console.WriteLine($"Песня '{song}' удалена из плейлиста.");
                break;
            }
        }
    }

    public void DisplayCurrentSong()
    {
        Console.WriteLine($"Текущая песня: {currentSong}");
    }

    public void DisplayPlayerState()
    {
        string state = isPlaying ? "Воспроизведение" : "Приостановлено";
        Console.WriteLine($"Состояние плеера: {state}");
    }

    public void DisplayPlaylist()
    {
        Console.WriteLine("Плейлист:");
        foreach (var song in playlist)
        {
            if (!string.IsNullOrEmpty(song))
            {
                Console.WriteLine(song);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        MusicPlayer player = new MusicPlayer();

        player.AddToPlaylist("Песня 1");
        player.AddToPlaylist("Песня 2");

        player.Play();
        player.DisplayPlayerState();
        player.DisplayCurrentSong();

        player.Next();
        player.Pause();
        player.DisplayPlayerState();

        player.SetVolume(75);

        player.RemoveFromPlaylist("Песня 1");

        player.DisplayPlaylist(); // Отображение плейлиста

        // Пример сортировки плейлиста по длине песен
        Array.Sort(player.GetPlaylist(), (song1, song2) => song1.Length.CompareTo(song2.Length));
        Console.WriteLine("Плейлист после сортировки:");
        player.DisplayPlaylist();
    }
}
