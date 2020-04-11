### Spotify Lyrics Grabber From Genius Lyrics or Happi Api

This application Reads current playing song from spotify Api and Grab the Lyrics from Happi api 

#### How To Use


-  Create an account from  [spotify Developer Page](https://developer.spotify.com/dashboard/login)

- add the given client Id and Client secret to appsetting.json file.(you can change the file name in config.json)

- If you want use happi api (If you want use Genius Lyrics just skip this one )
   - Create a Happi Account from [this link](https://happi.dev/ "this link")
   - Add The Api Key to appsetting.json (you can change the file name in config.json)
- for using Genius
  - remove HappiApi Section from config File and that will do it.

- Enjoy reading Lyrics

### Config File 

Just Be sure set configFile in configFile.json before start

in your config file you should set your api keys and if you need you can set proxy 

thanx to JohnnyCrazy from increadable Api : https://github.com/JohnnyCrazy/SpotifyAPI-NET
