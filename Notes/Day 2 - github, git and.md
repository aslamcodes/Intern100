- All github repos should be private
- Github copilot read from public repo

- any crictical infromation should'dt be pushed to github
## Alreadyu running and youre added as a collaborator
- Go to a location, where youre not collobtred already twith the system
- Git clone into
### Transcribe
- yashita's creating a branch 
- gaya also creating a branch
- now they're on different branch
- gaya commits some changes
- gaya pushes the branch to origni
- But it seems g3 is behind master
- so she pulls
- yashita created a g4 branch 
- shes on g4 branch
- she checouts to master
- and she merges with ```git merge g4```
- and she pushes to the origin master
- And it seems she behind the master
- so she pulls and merges
- and she finally pushes

We can do this with PR right

Gaya pushes the branch from g3 to master and raises a PR
PR - pulls the changes from raised branch to the pr branch
[[Git merge, rebase, squash]]
## Rebase
Merge is seperate commit
## Squash and Merge

## Rebase and Merge

## Cherry Pick
W3e have three branches Employee, Master, Customer

You are having two diff branches, instead of making in a correct branch you did uin antoithger branchg

instead of reset or rebase, you can cherry pick the last commit's hash and put in the right branch

get the commit hash from git log
and say 
```bash
git cherry-pich <hash>
```

The cherrypicked commit in the `newBranch` will have a different hash
## Deleting a Branch
-d ->Ask you to merge things 
-D ->force delete
```bash
git branch -d branch
```

```bash
git branch -D branch
```
### in the origin
(permanent damages) Organization may not allow it
```bash
git push -d branch
```
## Stashing
- your'e working on a project and your work is half done, suddenly something major has come up
- in that case, you stash the work in the branch
- 'Stash it away.' put somewhere 
```bash
git stash pop --index {{index}}
```


1. Pull
2. Work
3. Raise PR
4. Move Forward

# C\#

Employee Request Tracking

look for the authentic sourse
## Why .NET and C\#
-  
