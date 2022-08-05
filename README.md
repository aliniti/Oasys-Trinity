
# Trinity - Activator

Trinity is a plugin for the [Oasys](https://github.com/Oasys-Zone/Oasys.SDK) platform for allowing automatic item and spell usage without user input.

Spells and items can be configured to be "activated" at many in-game conditions.

## Health Prediction

One of the core parts of this plugin is that it has its own built in health prediction.

Health prediction is essential in order to predict the activation of defensive items and shields.
Items and spells will only be used it you are going to take predicted damage.

![](https://kurisumaki.se/push/2tPx3.png)

Trinity will try to predict incoming (and can be enabled/disabled):

- Tower shots
- Linear/Location/Direction/Targeted spells
- Basic auto attacks
- Basic minion attacks and neutral monster attacks
- Buffs that deal damage over time or that could kill you

![](https://kurisumaki.se/push/70eX8.png)

## Auto Shields 
Trinity will automatically attempt to shield self and allies on predicted income damage.

<p align="center">
  <img src="https://kurisumaki.se/push/86b7ae2c32.gif">
</p>

Supported Spells:
- Shields: Orianna, Diana, Janna, Garen, Lulu, Lux, Annie, Nautilus, and more.
- Low HP/Might Die: Zilean, Kindred, Lulu, Tryndamere, Soraka and more.
- Heals: Kayle, Nami, Seraphine, Sona, and more.
- Evadelike: MasterYi, Zed, Sivir, Morg, etc. 
