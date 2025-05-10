# Suicide Quick

**Un jeu de plateforme 2D développé avec Unity**

---

## 🎮 Présentation

**Suicide Quick** est un jeu de plateforme en 2D, construit sur une base Unity existante. Votre mission : guider le personnage à travers plusieurs niveaux, collecter des trophées, esquiver ou affronter des ennemis, et atteindre la fin de chaque niveau sans mourir. Ce projet met en pratique les notions de ScriptableObject, gestion de scènes, UI et mécaniques de jeu vues en cours.

---

## 🚀 Fonctionnalités

### Tâches impératives
- **Menu principal**  
  – Logo de l’université, titre du jeu, boutons « Jouer » & « Quitter », crédits, noms des développeurs, formation et année.
- **Niveaux**  
  – **Level1** (fourni) et **Level2** (créé), chacun avec un trophée déclenchant la scène suivante (ou l’écran de crédits).
- **Écran de pause**  
  – Activation/désactivation via Échap, boutons « Reprendre », « Recommencer » et « Menu principal ».
- **Checkpoints**  
  – Point de respawn mis à jour à chaque passage sur un checkpoint.
- **Blocs “désactivables”**  
  – Sprite changé, Collider2D désactivé après interaction.
- **Indicateur de vie**  
  – Barre de vie synchronisée avec les points de vie du joueur (via ScriptableObject).
- **Game Over**  
  – Écran « Game Over » à la mort du joueur, avec choix « Recommencer » ou « Menu principal ».
- **Écran des crédits**  
  – Liste des pseudos du groupe, sources des assets (PixelFrog, OpenGameArt…), logo université, formation & année, bouton « Retour ».

### Choix optionnels réalisés
- **Musique de fond**  
  – Boucle audio jouée dès la scène `_Preload`, gérée par un AudioSource.
- **Attaque “impact” au sol**  
  – Coup spécial en appuyant sur S en l’air, infligeant des dégâts aux ennemis proches via `Physics2D.OverlapCircleAll()`.

---

## ⚙️ Installation & ouverture

1. **Cloner le projet**  
   ```bash
   git clone git@github.com:VOTRE_COMPTE/SuicideQuick.git
   cd SuicideQuick

 
