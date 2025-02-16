---
title: Remove Mesh in Box
weight: 25
---

# Remove Mesh in Box

箱で指定した範囲内のポリゴンを削除します。

このコンポーネントは[Modifying Edit Skinned Mesh Component](../../component-kind/edit-skinned-mesh-components#modifying-component)であるため、SkinnedMeshRendererコンポーネントのあるGameObjectに追加してください。

## 設定 {#settings}

数値を調整して箱を追加します。
それぞれの箱について、中心位置、大きさ、角度を変更することが出来ます。(ローカル座標で指定します)

![component.png](component.png)

`Edit This Box`をクリックして下図のようなギズモを表示します。箱の大きさ、位置、角度を調整することが出来ます。

<img src="gizmo.png" width="563">

## 例 {#Example}

上側の図にある箱の範囲内のメッシュが、下側の図のように削除されます。

<img src="before.png" width="403">
<img src="after.png" width="403">
