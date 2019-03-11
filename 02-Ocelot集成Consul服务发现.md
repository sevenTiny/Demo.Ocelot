# 02-Ocelot集成Consul服务发现

## 本Demo包含部分：
1. Consul的安装部署
2. 三个下游Demo集成Consul
3. Ocelot网关集成Consul


## 详：

## 一、Consul的安装部署
1. 下载Consul，地址[Consul](https://www.consul.io/downloads.html)
	如果不想下载的可以查看我们项目根目录Consul文件夹下找到对应的下载好的Consul文件
2. 运行Consul
	如果是Window的Consul exe，则cmd到Condul.exe目录下，运行命令：consul.exe agent -dev
	然后consul的服务就启动起来了，这是默认的没有任何配置文件的consul服务
	我们可以在浏览器地址http://localhost:8500/ui查看consul的状态

## 二、三个下游Demo集成Consul
1. 我们在三个下游微服务项目安装Nuget：Consul 最新稳定版
2. 在子服务中的Programe.cs文件中配置启动的端口
3. 在子服务中的StartUp.cs文件中配置Consul相关注册和注销代码
4. 在子服务中分别添加健康检查控制器，详见代码

## 三、Ocelot网关集成Consul
1. Ocelot.json配置文件中配置Consul的集成，Consul的端口
2. 网关项目的StartUp.cs文件中配置Consul的集成

## 四、运行
1. 使用第一步中的介绍运行Consul
2. 分别从三个子服务的生成bin目录找到子服务的dll，然后在当前路径使用命令：dotnet Service1.dll （其他类推）
3. 我们现在就可以在Consul的UI界面查看到我们的三个服务节点已经上线
4. 启动网关项目，然后我们访问我们的子服务地址，重复访问可以看到我们已经轮询到了不同的子服务上

注意：
需要从命令行host服务测试才行

（完）

7tiny
2019年3月11日 10点03分
