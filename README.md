Void
====

Not a wow bot!

Research
====

Hooking
==

    http://www.thebuddyforum.com/archives/5113-apocs-lua-event-hooks-beta.html
    http://www.ownedcore.com/forums/world-of-warcraft/world-of-warcraft-bots-programs/wow-memory-editing/341648-src-c-bananahook-simple-abstracted-api-hooking-library.html
    http://spazzarama.com/2011/03/14/c-screen-capture-and-overlays-for-direct3d-9-10-and-11-using-api-hooks/
    http://www.ownedcore.com/forums/world-of-warcraft/world-of-warcraft-bots-programs/wow-memory-editing/299810-c-tutorial-how-become-endscene-hooker.html

Navigation
==

    ADT Render
        www.ownedcore.com/forums/world-of-warcraft/world-of-warcraft-bots-programs/wow-memory-editing/276410-building-navmesh-out-of-adts.html
        www.ownedcore.com/forums/general/programming/253117-sources-c-adt-viewer-help-wanted.html
        http://web.archive.org/web/20080627102824/http://www.mpqnav.com/page/2/

    Navigation
        www.ai-blog.net/archives/000152.html
        http://www.ownedcore.com/forums/world-of-warcraft/world-of-warcraft-bots-programs/251315-source-pathing-3d-viewer.html
        http://www.ownedcore.com/forums/general/programming/237023-bot-developers-simple-waypoint-navigation-system-including-loading-saving.html
        http://www.ownedcore.com/forums/world-of-warcraft/world-of-warcraft-bots-programs/wow-memory-editing/317944-path-generator-recast-detour-wowmapper-step.html
        http://cotdp.com/2011/06/navigation-mesh-path-finding-in-mmorpg-bots/
        http://www.ownedcore.com/forums/world-of-warcraft/world-of-warcraft-bots-programs/wow-memory-editing/310667-tool-navmesh-creator-8.html#post2015848

    CTM
        http://www.ownedcore.com/forums/world-of-warcraft/world-of-warcraft-bots-programs/wow-memory-editing/372899-help-ctm-auto-loot-prob.html
    Minimap
        http://www.ownedcore.com/forums/world-of-warcraft/world-of-warcraft-bots-programs/294567-release-maprender-minimap-viewer.html
        http://www.iamcal.com/world-of-mapcraft/
        http://mapwow.com/


Combat
==

    Calling LUA Functions
        http://www.ownedcore.com/forums/world-of-warcraft/world-of-warcraft-bots-programs/wow-memory-editing/371785-lua-do-string.html#post2449372
        http://www.ownedcore.com/forums/world-of-warcraft/world-of-warcraft-bots-programs/wow-memory-editing/328485-code-encapsulating-spell-book.html




Scripting
==

    http://www.gamedev.net/page/resources/_/technical/game-programming/using-lua-with-c-r2275
    http://moonscript.org/

General Resource
==

    http://www.pxr.dk/wowdev/wiki/index.php?title=Main_Page



Hooks & Endscene
==

    http://www.ownedcore.com/forums/world-of-warcraft/world-of-warcraft-bots-programs/wow-memory-editing/316770-lets-learn-concepts-endscene-hooks-sufferin-succotash-quick-into-codecave.html
    http://www.ownedcore.com/forums/world-of-warcraft/world-of-warcraft-bots-programs/wow-memory-editing/334813-dx11-endscene-hook.html
    http://www.ownedcore.com/forums/world-of-warcraft/world-of-warcraft-bots-programs/wow-memory-editing/305473-sample-code-endscene-hook-asm-blackmagic.html


Rendering
==

    http://spazzarama.com/2010/03/29/screen-capture-with-direct3d-api-hooks/




http://www.ownedcore.com/forums/world-of-warcraft/world-of-warcraft-bots-programs/wow-memory-editing/307988-example-c-bot-base-4-0-1-a.html

http://www.ownedcore.com/forums/world-of-warcraft/world-of-warcraft-bots-programs/wow-memory-editing/315561-cleancore-3.html

http://www.progamercity.net/wow-hacks/3891-source-c-memory-pixel-bot-world-warcraft.html






http://www.pudn.com/downloads186/sourcecode/windows/csharp/detail873185.html

https://github.com/tanis2000/babbot
http://www.pudn.com/downloads186/sourcecode/windows/csharp/detail873185.html






public int GetAggroRadius(CreatureObject LocalPlayer)
       {
           // if they are the same level as us, the aggro radius is roughly 20 yards
           int AggroRadius = 20;
           // aggro radius varies with level difference at a rate of roughly 1 yard/level
           if (LocalPlayer.Level > Level)
               AggroRadius -= (int)BotControl.DifferenceBetween(LocalPlayer.Level, Level);
           if (LocalPlayer.Level < Level)
               AggroRadius += (int)BotControl.DifferenceBetween(LocalPlayer.Level, Level);
           if (AggroRadius < 5)
               AggroRadius = 5;
           AggroRadius += 3; // give us a bit of leeway
           return AggroRadius;
       }