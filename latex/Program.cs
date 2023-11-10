/**
 * @file
 * @brief Музыкальный плеер и его интерфейс
 */

using System;

/**
 * @brief Интерфейс музыкального плеера
 */
public interface IMusicPlayer
{
    /**
     * @brief Начать воспроизведение
     */
    void Play();

    /**
     * @brief Приостановить воспроизведение
     */
    void Pause();

    /**
     * @brief Остановить воспроизведение
     */
    void Stop();

    /**
     * @brief Перейти к следующей песне
     */
    void Next();

    /**
     * @brief Перейти к предыдущей песне
     */
    void Previous();

    /**
     * @brief Установить громкость плеера
     * @param volume Уровень громкости (от 0 до 100)
     */
    void SetVolume(int volume);

    /**
     * @brief Добавить песню в плейлист
     * @param song Название добавляемой песни
     */
    void AddToPlaylist(string song);

    /**
     * @brief Удалить песню из плейлиста
     * @param song Название удаляемой песни
     */
    void RemoveFromPlaylist(string song);

    /**
     * @brief Отобразить текущую песню
     */
    void DisplayCurrentSong();

    /**
     * @brief Отобразить состояние плеера (воспроизведение/приостановлено)
     */
    void DisplayPlayerState();

    /**
     * @brief Отобразить плейлист
     */
    void DisplayPlaylist();
}

/**
 * @brief Класс музыкального плеера
 */
public class MusicPlayer : IMusicPlayer
{
    private string currentSong;
    private int volume;
    private bool isPlaying;
    private string[] playlist = new string[10];
    private int playlistIndex = 0;

    /**
     * @brief Начать воспроизведение
     */
    public void Play()
    {
        isPlaying = true;
        Console.WriteLine("Воспроизведение начато.");
    }

    /**
     * @brief Приостановить воспроизведение
     */
    public void Pause()
    {
        isPlaying = false;
        Console.WriteLine("Воспроизведение приостановлено.");
    }

    /**
     * @brief Остановить воспроизведение
     */
    public void Stop()
    {
        isPlaying = false;
        Console.WriteLine("Воспроизведение остановлено.");
    }

    /**
     * @brief Перейти к следующей песне
     */
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

    /**
     * @brief Перейти к предыдущей песне
     */
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

    /**
     * @brief Установить громкость плеера
     * @param volume Уровень громкости (от 0 до 100)
     */
    public void SetVolume(int volume)
    {
        this.volume = volume;
        Console.WriteLine($"Громкость установлена на {volume}%.");
    }

    /**
     * @brief Добавить песню в плейлист
     * @param song Название добавляемой песни
     */
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

    /**
     * @brief Удалить песню из плейлиста
     * @param song Название удаляемой песни
     */
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

    /**
     * @brief Отобразить текущую песню
     */
    public void DisplayCurrentSong()
    {
        Console.WriteLine($"Текущая песня: {currentSong}");
    }

    /**
     * @brief Отобразить состояние плеера (воспроизведение/приостановлено)
     */
    public void DisplayPlayerState()
    {
        string state = isPlaying ? "Воспроизведение" : "Приостановлено";
        Console.WriteLine($"Состояние плеера: {state}");
    }

    /**
     * @brief Отобразить плейлист
     */
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

/**
 * @brief Основной класс программы
 */
class Program
{
    /**
     * @brief Точка входа в программу
     * @param args Аргументы командной строки
     */
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
