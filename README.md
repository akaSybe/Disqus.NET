# Disqus.NET

## Example usage

* Get forum details

```C#

var disqus = new DisqusApi(DisqusAuthMethod.SecretKey, DisqusKey);

var request = DisqusForumDetailsRequest
    .New("disqus")
    .Related(DisqusForumRelated.Author)
    .Attach(DisqusForumAttach.ForumForumCategory | DisqusForumAttach.Counters);

var response = await disqus.Forums.DetailsAsync(request).ConfigureAwait(false);

```

## Resources

- [Announcements](https://disqus.com/api/docs/announcements/)

- [Announcements/Templates](https://disqus.com/api/docs/announcements/templates/)

- [Applications](https://disqus.com/api/docs/applications/)
    - [listUsage](https://disqus.com/api/docs/applications/listUsage/) [completed]

- [Blacklists](https://disqus.com/api/docs/blacklists/)
    - [add](https://disqus.com/api/docs/blacklists/add/) [completed]
    - ~~[backfillCounters](https://disqus.com/api/docs/blacklists/backfillCounters/)~~
    - [list](https://disqus.com/api/docs/blacklists/list/) [completed]
    - [remove](https://disqus.com/api/docs/blacklists/remove/) [completed]

- [Category](https://disqus.com/api/docs/categories/)
    - [create](https://disqus.com/api/docs/categories/create/) [completed]
	- [details](https://disqus.com/api/docs/categories/details/) [completed]
    - [list](https://disqus.com/api/docs/categories/list/) [completed]
    - [listPosts](https://disqus.com/api/docs/categories/listPosts/) [completed]
    - [listThreads](https://disqus.com/api/docs/categories/listThreads/) [completed]

- [Exports](https://disqus.com/api/docs/exports/)
    - [exportForum](https://disqus.com/api/docs/exports/exportForum/) [completed]

- [ForumCategory](https://disqus.com/api/docs/forumCategories/)
    - [details](https://disqus.com/api/docs/forumCategories/details/) [completed]
    - [list](https://disqus.com/api/docs/forumCategories/list/) [completed]

- [Forums](https://disqus.com/api/docs/forums/)
    - [addModerator](https://disqus.com/api/docs/forums/addModerator/) [completed]
    - [create](https://disqus.com/api/docs/forums/create/) [completed]
    - [details](https://disqus.com/api/docs/forums/details/) [completed]
    - [disableAds](https://disqus.com/api/docs/forums/disableAds/) [completed]
    - ~~[fixFavIconsForClassifiedForums](https://disqus.com/api/docs/forums/fixFavIconsForClassifiedForums/)~~
    - [follow](https://disqus.com/api/docs/forums/follow/) [completed]
    - ~~[generateInterestingContent](https://disqus.com/api/docs/forums/generateInterestingContent/)~~
    - [interestingForums](https://disqus.com/api/docs/forums/interestingForums/) [completed]
    - [listCategories](https://disqus.com/api/docs/forums/listCategories/) [completed]
    - [listFollowers](https://disqus.com/api/docs/forums/listFollowers/) [completed]
    - [listModerators](https://disqus.com/api/docs/forums/listModerators/) [completed]
    - [listMostActiveUsers](https://disqus.com/api/docs/forums/listMostActiveUsers/) [completed]
    - [listMostLikedUsers](https://disqus.com/api/docs/forums/listMostLikedUsers/) [completed]
    - [listPosts](https://disqus.com/api/docs/forums/listPosts/) [completed]
    - [listThreads](https://disqus.com/api/docs/forums/listThreads/) [completed]
    - [listUsers](https://disqus.com/api/docs/forums/listUsers/) [completed]
    - [removeDefaultAvatar](https://disqus.com/api/docs/forums/removeDefaultAvatar/) [completed]
    - [removeModerator](https://disqus.com/api/docs/forums/removeModerator/) [completed]
    - [unfollow](https://disqus.com/api/docs/forums/unfollow/) [completed]
    - [update](https://disqus.com/api/docs/forums/update/) [completed]
    - [updateDefaultAvatar](https://disqus.com/api/docs/forums/updateDefaultAvatar/)
    - [validate](https://disqus.com/api/docs/forums/validate/) [completed]

- [Imports](https://disqus.com/api/docs/imports/)
    - [details](https://disqus.com/api/docs/imports/details/) [completed]
    - [list](https://disqus.com/api/docs/imports/list/) [completed]

- [Media](https://disqus.com/api/docs/media/)

- [Organizations](https://disqus.com/api/docs/organizations/)
    - [addAdmin](https://disqus.com/api/docs/organizations/addAdmin/) [completed]
    - [listAdmins](https://disqus.com/api/docs/organizations/listAdmins/) [completed]
    - [removeAdmin](https://disqus.com/api/docs/organizations/removeAdmin/) [completed]
    - [setRole](https://disqus.com/api/docs/organizations/setRole/) [completed]

- [Posts](https://disqus.com/api/docs/posts/)
    - [approve](https://disqus.com/api/docs/posts/approve/) [completed]
    - [create](https://disqus.com/api/docs/posts/create/) [completed]
    - [details](https://disqus.com/api/docs/posts/details/) [completed]
    - [getContext](https://disqus.com/api/docs/posts/getContext/) [completed]
    - [list](https://disqus.com/api/docs/posts/list/) [completed]
    - [listPopular](https://disqus.com/api/docs/posts/listPopular/) [completed]
    - [remove](https://disqus.com/api/docs/posts/remove/) [completed]
    - [report](https://disqus.com/api/docs/posts/report/) [completed]
    - [restore](https://disqus.com/api/docs/posts/restore/) [completed]
    - [spam](https://disqus.com/api/docs/posts/spam/) [completed]
    - [update](https://disqus.com/api/docs/posts/update/) [completed]
    - [vote](https://disqus.com/api/docs/posts/vote/) [completed]

- [Threads](https://disqus.com/api/docs/threads/)
    - [approve](https://disqus.com/api/docs/threads/approve/) [completed]
    - [close](https://disqus.com/api/docs/threads/close/) [completed]
    - [create](https://disqus.com/api/docs/threads/create/) [completed]
    - [details](https://disqus.com/api/docs/threads/details/) [completed]
    - [list](https://disqus.com/api/docs/threads/list/) [completed]
    - [listHot](https://disqus.com/api/docs/threads/listHot/) [completed]
    - [listPopular](https://disqus.com/api/docs/threads/listPopular/) [completed]
    - [listPosts](https://disqus.com/api/docs/threads/listPosts/) [completed]
    - [listUsersVotedThread](https://disqus.com/api/docs/threads/listUsersVotedThread/) [completed]
    - [open](https://disqus.com/api/docs/threads/open/) [completed]
    - [remove](https://disqus.com/api/docs/threads/remove/) [completed]
    - [restore](https://disqus.com/api/docs/threads/restore/) [completed]
    - [set](https://disqus.com/api/docs/threads/set/) [completed]
    - [spam](https://disqus.com/api/docs/threads/spam/) [completed]
    - [subscribe](https://disqus.com/api/docs/threads/subscribe/) [completed]
    - [unsubscribe](https://disqus.com/api/docs/threads/unsubscribe/) [completed]
    - [update](https://disqus.com/api/docs/threads/update/) [completed]
    - [vote](https://disqus.com/api/docs/threads/vote/) [completed]

- [Topics](https://disqus.com/api/docs/topics/)
    - ~~[update](https://disqus.com/api/docs/topics/update/)~~

- [Trends](https://disqus.com/api/docs/trends/)
    - [listThreads](https://disqus.com/api/docs/trends/listThreads/) [completed]

- [TrustedDomain](https://disqus.com/api/docs/forums/trustedDomain/)
    - [create](https://disqus.com/api/docs/forums/trustedDomain/create/) [completed]
    - [kill](https://disqus.com/api/docs/forums/trustedDomain/kill/) [completed]
    - [list](https://disqus.com/api/docs/forums/trustedDomain/list/) [completed]

- [Users](https://disqus.com/api/docs/users/)
    - [checkUsername](https://disqus.com/api/docs/users/checkUsername/) [completed]
    - [details](https://disqus.com/api/docs/users/details/) [completed]
    - [follow](https://disqus.com/api/docs/users/follow/) [completed]
    - [interestingUsers](https://disqus.com/api/docs/users/interestingUsers/) [completed]
    - [listActiveForums](https://disqus.com/api/docs/users/listActiveForums/) [completed]
    - [listActivity](https://disqus.com/api/docs/users/listActivity/) [completed]
    - [listFollowers](https://disqus.com/api/docs/users/listFollowers/) [completed]
    - [listFollowing](https://disqus.com/api/docs/users/listFollowing/) [completed]
    - [listFollowingChannels](https://disqus.com/api/docs/users/listFollowingChannels/)
    - [listFollowingForums](https://disqus.com/api/docs/users/listFollowingForums/) [completed]
    - [listForums](https://disqus.com/api/docs/users/listForums/) [completed]
    - [listModeratedChannels](https://disqus.com/api/docs/users/listModeratedChannels/)
    - [listMostActiveForums](https://disqus.com/api/docs/users/listMostActiveForums/) [completed]
    - [listOwnedChannels](https://disqus.com/api/docs/users/listOwnedChannels/)
    - [listPosts](https://disqus.com/api/docs/users/listPosts/) [completed]
    - [removeFollower](https://disqus.com/api/docs/users/removeFollower/) [completed]
    - [report](https://disqus.com/api/docs/users/report/) [completed]
    - [unfollow](https://disqus.com/api/docs/users/unfollow/) [completed]
    - [updateProfile](https://disqus.com/api/docs/users/updateProfile/) [completed]

- [Whitelists](https://disqus.com/api/docs/whitelists/)
    - [add](https://disqus.com/api/docs/whitelists/add/) [completed]
    - [list](https://disqus.com/api/docs/whitelists/list/) [completed]
    - [remove](https://disqus.com/api/docs/whitelists/remove/) [completed]
