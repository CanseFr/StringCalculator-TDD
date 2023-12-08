# StringCalculator-TDD

# Evaluation Clean Code

- L'objectif de cette évaluation n'est pas forcément de réaliser le code en entier, mais d'appliquer au maximum la
  méthodologie TDD et les conseils de Clean Code vu durant la formation.

## Règles

- La technologie utilisée n'a pas d'importance **tant que c'est de l'orienté objet** (mais vous devrez vous débrouiller
  si vous avez un souci lié au langage)
- Réaliser une TDD de A à Z
- Respecter le Clean Code au maximum
- Le code est bien factorisé (ça fait partie du TDD)
- Si vous factorisez des tests, mettez les en commentaires plutôt que de les supprimer
- Si vous modifiez l'ordre de vos tests (de haut en bas étant l'ordre normal), numérotez vos tests dans l'ordre de
  réalisation de ces derniers
- Rendez moi un zip sans les dossiers bin et obj des deux projets (MSTests & Console) à m'envoyer sur discord
- **OU** Rendez moi un lien de repository github (public ou alors privé en me filant les droits) à m'envoyer sur discord

## Notation

- La notation se fera sur :
    - La TDD mise en place et la reflexion associée
    - Le respect des normes de Clean Code vus ensemble
    - La factorisation du code
    - Juste un peu sur le pourcentage de réalisation de l'exercice (Comme expliqué, l'objectif n'est pas de finaliser
      l'exercice à 100% mais de bien respecter les règles. C'est juste qu'entre quelqu'un qui a fait parfaitement l'
      exercice à 100% et quelqu'un qui l'a fait parfaitement à 50%, il y aura forcément une légère différence de
      notation)

## Sujet

- Réaliser une TDD permettant de mettre en oeuvre le sujet suivant :
- Gestion d'une calculatrice plus complexe qui prend en paramètre un string qui contient les nombres que l'on souhaite
  additionner séparé par une virgule.
- Quelques règles :
    - L'addition ne peut pas accepter d'élements négatifs (ils doivent être gérés cependant, si nombre négatif, nombre
      considéré comme 0 dans l'addition)
    - Un nombre ne peut pas être supérieur à 1000 (si nombre supérieur à 1000, le nombre est considéré comme 0 dans
      l'addition)
    - Le délimiteur peut être changé et devenir ; ou *. La chaîne d'entrée est à adapter, par exemple : "//*/1*2"
      signifie que le delimiteur est devenu *. Si la chaîne ne commence pas par // alors aucun délimiteur spécifique
      n'est à utiliser.
- Par exemple :
    - "0,1,2,3,4,555" donne le résultat 565.
    - "1" donne le résultat 1
    - "3,-2,5" donne 8
    - ... (Je ne donne pas tous les cas d'usage à gérer intentionnellement !)
- Vous devez donc avoir une classe CalculatorString qui gère la méthode d'addition et toutes ses spécificités
- La difficulté de cette proposition est de réfléchir par vous même à toutes les possibilités qui peuvent être envoyées
  dans cette string en entrée et vous assurer que ça gère les cas d'erreurs correctement et que ça gère les cas corrects
  avec un retour de l'addition voulue.
  Réduire
  Evaluaton_CleanCode.md
  3 Ko
