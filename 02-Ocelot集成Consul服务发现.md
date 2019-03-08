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

## 三、Ocelot网关集成Consul


需要从命令行host服务测试才行
网关记得要装consul，并配置

（完）

7tiny
2019年3月8日 18点03分
